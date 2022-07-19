using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center")]
    [AllowAnonymous]
    public class BuildingController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public BuildingController(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("building")]
        [HttpPost]
        public async Task<ICommandResult> CreateBuilding(
           [FromBody] CreateBuildingCommand command,
           [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBuilding(
            [FromRoute] Guid id,
            [FromBody] CreateBuildingCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var building = await _repository.FindBuildingById(id);
                building.Name = command.Name;
                building.TrackModifiedDate();
                _repository.UpdateBuilding(building);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Prédio atualizado com sucesso", building));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar prédio", new { id }));
            }
        }

        [Route("building")]
        [HttpGet]
        public async Task<IEnumerable<Building>> FindAllBuildings()
        {
            return await _repository.FindAllBuildings();
        }

        [Route("building/{id}")]
        [HttpGet]
        public async Task<Building> FindBuildingById(Guid id)
        {
            return await _repository.FindBuildingById(id);
        }


        [Route("building/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteBuilding(Guid id)
        {
            try
            {
                var building = new Building();
                building.SetId(id);
                _repository.DeleteBuilding(building);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}