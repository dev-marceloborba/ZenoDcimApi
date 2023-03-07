using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Commands.Outputs;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center/sites")]
    [AllowAnonymous]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _repository;
        private readonly ISiteCardSettingsRepository _cardRepository;

        public SiteController(ISiteRepository repository, ISiteCardSettingsRepository cardRepository)
        {
            _repository = repository;
            _cardRepository = cardRepository;
        }

        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreateSite(
            [FromBody] CreateSiteCommand command,
            [FromServices] SiteHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSite(
            [FromRoute] Guid id,
            [FromBody] CreateSiteCommand command,
            [FromServices] SiteHandler handler)
        {
            try
            {
                var site = await _repository.FindByIdAsync(id);
                site.Name = command.Name;
                site.TrackModifiedDate();
                _repository.Update(site);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Site atualizado com sucesso", site));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar o site", new { id }));
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Site>> FindAllSites()
        {
            return await _repository.FindAllAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> FindSiteById(
            [FromRoute] Guid id
        )
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSite(
            [FromRoute] Guid id)
        {
            try
            {
                var site = await _repository.FindByIdAsync(id);
                var card = site.CardSettings;
                _cardRepository.Delete(card);
                _repository.Delete(site);
                await _repository.Commit();
                return Ok(site);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("load-cards")]
        public async Task<ActionResult> ListCards()
        {
            var result = await _repository.LoadSiteCards();
            return Ok(result);
        }

        [HttpGet]
        [Route("duplicate/{id}")]
        public async Task<ActionResult> Duplicate(
            [FromRoute] Guid id
        )
        {
            var site = await _repository.FindByIdAsync(id);
            var duplicated = site.Duplicate();

            for (int i = 0; i < duplicated.Buildings.Count; i++)
            {
                duplicated.Buildings[i] = duplicated.Buildings[i].Clone();
                duplicated.Buildings[i].SiteId = duplicated.Buildings[i].Site.Id;
                // duplicated.Buildings[i].SiteId = duplicated.Id;
                for (int j = 0; j < duplicated.Buildings[i].Floors.Count; j++)
                {
                    duplicated.Buildings[i].Floors[j] = duplicated.Buildings[i].Floors[j].Clone();
                    duplicated.Buildings[i].Floors[j].BuildingId = duplicated.Buildings[i].Id;
                    for (int k = 0; k < duplicated.Buildings[i].Floors[j].Rooms.Count; k++)
                    {
                        duplicated.Buildings[i].Floors[j].Rooms[k] = duplicated.Buildings[i].Floors[j].Rooms[k].Clone();
                        duplicated.Buildings[i].Floors[j].Rooms[k].FloorId = duplicated.Buildings[i].Floors[j].Id;
                        for (int l = 0; l < duplicated.Buildings[i].Floors[j].Rooms[k].Equipments.Count; l++)
                        {
                            duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l] = duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].Clone();
                            duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].RoomId = duplicated.Buildings[i].Floors[j].Rooms[k].Id;
                            for (int m = 0; m < duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters.Count; m++)
                            {
                                duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m] = duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].Clone();
                                duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].EquipmentId = duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].Id;
                                for (int n = 0; n < duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].AlarmRules.Count; n++)
                                {
                                    duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].AlarmRules[n] = duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].AlarmRules[n].Clone();
                                    duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].AlarmRules[n].EquipmentParameterId = duplicated.Buildings[i].Floors[j].Rooms[k].Equipments[l].EquipmentParameters[m].Id;
                                }
                            }
                        }
                    }
                }
            }

            await _repository.CreateAsync(duplicated);
            await _repository.Commit();
            return Ok(duplicated);
        }

        [HttpGet]
        [Route("occupation-card")]
        public async Task<ActionResult> GetOccupationCard(
            [FromServices] ZenoContext context
        )
        {
            var output = new List<OccupiedOutput>();
            var sites = await context.Sites
                .AsNoTracking()
                .Include(x => x.Buildings)
                    .ThenInclude(x => x.Floors)
                    .ThenInclude(x => x.Rooms)
                    .ThenInclude(x => x.Racks)
                    .ThenInclude(x => x.RackEquipments)
                .ToListAsync();

            foreach (var site in sites)
            {
                output.Add(new OccupiedOutput
                {
                    Id = site.Id,
                    Name = site.Name,
                    PowerCapacity = site.GetPowerCapacity(),
                    RackCapacity = site.GetRackCapacity(),
                    OccupiedPower = site.GetOccupiedPower(),
                    OccupiedCapacity = site.GetOccupiedCapacity(),
                    RacksQuantity = site.GetRacksQuantity(),
                    RoomsQuantity = site.GetRoomsQuantity()
                });
            }


            return Ok(output);
        }
    }
}