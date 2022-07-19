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
    public class FloorController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public FloorController(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor")]
        [HttpPost]
        public async Task<ICommandResult> CreateFloor(
            [FromBody] CreateFloorCommand command,
            [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFloor(
            [FromRoute] Guid id,
            [FromBody] CreateFloorCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var floor = await _repository.FindFloorById(id);
                floor.Name = command.Name;
                floor.TrackModifiedDate();
                _repository.UpdateFloor(floor);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Andar atualizado com sucesso", floor));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Falha ao atualizar andar", new { id }));
            }
        }

        [Route("building/floor")]
        [HttpGet]
        public async Task<IEnumerable<Floor>> FindAllFloors()
        {
            return await _repository.FindAllFloors();
        }

        [Route("building/floor/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteFloor(Guid id)
        {
            try
            {
                var floor = new Floor();
                floor.SetId(id);
                _repository.DeleteFloor(floor);
                await _repository.Commit();
                return Ok(floor);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}