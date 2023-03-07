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
    [Route("v1/data-center/building")]
    [AllowAnonymous]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository _repository;
        private readonly IBuildingCardSettingsRepository _cardRepository;

        public BuildingController(IBuildingRepository repository, IBuildingCardSettingsRepository cardRepository)
        {
            _repository = repository;
            _cardRepository = cardRepository;
        }

        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreateBuilding(
           [FromBody] CreateBuildingCommand command,
           [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBuilding(
            [FromRoute] Guid id,
            [FromBody] CreateBuildingCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var building = await _repository.FindByIdAsync(id);
                building.Name = command.Name;
                building.SiteId = command.SiteId;
                building.TrackModifiedDate();
                _repository.Update(building);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Prédio atualizado com sucesso", building));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar prédio", new { id }));
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Building>> FindAllBuildings()
        {
            return await _repository.FindAllAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<Building> FindBuildingById(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteBuilding(Guid id)
        {
            try
            {
                var building = await _repository.FindByIdAsync(id);
                var card = building.CardSettings;

                _repository.Delete(building);
                _cardRepository.Delete(card);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("load-cards/{id}")]
        [HttpGet]
        public async Task<ActionResult> LoadCards(
            [FromRoute] Guid id
        )
        {
            var result = await _repository.LoadBuildingCards(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("duplicate/{id}")]
        public async Task<ActionResult> Duplicate(
            [FromRoute] Guid id
        )
        {
            var building = await _repository.FindByIdAsync(id);
            var duplicated = building.Duplicate();
            return Ok(duplicated);
        }

        [HttpGet]
        [Route("occupation-card/{id}")]
        public async Task<ActionResult> GetOccupationCard(
            [FromRoute] Guid id,
            [FromServices] ZenoContext context
        )
        {
            var output = new List<OccupiedOutput>();
            var buildings = await context.Buildings
                .AsNoTracking()
                .Include(x => x.Floors)
                    .ThenInclude(x => x.Rooms)
                    .ThenInclude(x => x.Racks)
                    .ThenInclude(x => x.RackEquipments)
                .Where(x => x.SiteId == id)
                .ToListAsync();

            var rooms = await context.Rooms
                .AsNoTracking()
                .Where(x => x.RackCapacity > 0)
                .ToListAsync();

            foreach (var building in buildings)
            {
                output.Add(new OccupiedOutput
                {
                    Id = building.Id,
                    Name = building.Name,
                    PowerCapacity = building.GetPowerCapacity(),
                    RackCapacity = building.GetRackCapacity(),
                    OccupiedPower = building.GetOccupiedPower(),
                    OccupiedCapacity = building.GetOccupiedCapacity(),
                    RacksQuantity = building.GetRacksQuantity(),
                    RoomsQuantity = building.GetRoomsQuantity()
                });
            }

            return Ok(output.Where(x => x.RackCapacity > 0));
        }
    }
}