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
    [Route("v1/data-center")]
    [AllowAnonymous]
    public class FloorController : ControllerBase
    {
        private readonly IFloorRepository _repository;

        public FloorController(IFloorRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor")]
        [HttpPost]
        public async Task<ICommandResult> CreateFloor(
            [FromBody] CreateFloorCommand command,
            [FromServices] FloorHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFloor(
            [FromRoute] Guid id,
            [FromBody] CreateFloorCommand command,
            [FromServices] FloorHandler handler)
        {
            try
            {
                var floor = await _repository.FindByIdAsync(id);
                floor.Name = command.Name;
                floor.BuildingId = command.BuildingId;
                floor.TrackModifiedDate();
                _repository.Update(floor);
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
            return await _repository.FindAllAsync();
        }

        [Route("building/floor/{id}")]
        [HttpGet]
        public async Task<ActionResult> FindFloorById(
            [FromRoute] Guid id
        )
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }

        [Route("building/floor/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteFloor(Guid id)
        {
            try
            {
                var floor = new Floor();
                floor.SetId(id);
                _repository.Delete(floor);
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