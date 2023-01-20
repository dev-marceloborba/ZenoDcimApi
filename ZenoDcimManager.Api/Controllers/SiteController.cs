using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center/sites")]
    [AllowAnonymous]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _repository;

        public SiteController(ISiteRepository repository)
        {
            _repository = repository;
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
                var site = new Site();
                site.SetId(id);
                _repository.Delete(site);
                await _repository.Commit();
                return Ok(site);
            }
            catch
            {
                return BadRequest();
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
    }
}