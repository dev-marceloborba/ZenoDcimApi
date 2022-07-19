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
    [Route("/v1/data-center")]
    [AllowAnonymous]
    public class RoomController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public RoomController(IDataCenterRepository repository)
        {
            _repository = repository;
        }
        [Route("building/floor/room")]
        [HttpPost]
        public async Task<ICommandResult> CreateRoom(
           [FromBody] CreateRoomCommand command,
           [FromServices] BuildingHandler handler
       )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(
            [FromRoute] Guid id,
            [FromBody] CreateRoomCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var room = await _repository.FindRoomById(id);
                room.Name = command.Name;
                room.TrackModifiedDate();
                _repository.UpdateRoom(room);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Sala atualizada com sucesso", room));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar sala", new { id }));
            }
        }

        [Route("building/floor/room")]
        [HttpGet]
        public async Task<IEnumerable<Room>> FindAllRooms()
        {
            return await _repository.FindAllRooms();
        }

        [Route("building/floor/room/{id}")]
        [HttpGet]
        public async Task<Room> FindRoomById(Guid id)
        {
            return await _repository.FindRoomById(id);
        }

        [Route("building/floor/room/{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteRoom(Guid id)
        {
            try
            {
                var room = new Room();
                room.SetId(id);
                _repository.DeleteRoom(room);
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