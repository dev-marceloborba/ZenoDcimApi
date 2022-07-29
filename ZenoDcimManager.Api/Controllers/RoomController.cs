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
    [Route("/v1/data-center")]
    [AllowAnonymous]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _repository;

        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }
        [Route("building/floor/room")]
        [HttpPost]
        public async Task<ICommandResult> CreateRoom(
           [FromBody] CreateRoomCommand command,
           [FromServices] RoomHandler handler
       )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(
            [FromRoute] Guid id,
            [FromBody] CreateRoomCommand command,
            [FromServices] RoomHandler handler)
        {
            try
            {
                var room = await _repository.FindByIdAsync(id);
                room.Name = command.Name;
                room.TrackModifiedDate();
                _repository.Update(room);
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
            return await _repository.FindAllAsync();
        }

        [Route("building/floor/room/{id}")]
        [HttpGet]
        public async Task<Room> FindRoomById(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }

        [Route("rooms-by-floor/{id}")]
        [HttpGet]
        public IEnumerable<Room> FindRoomsByFloorId(
            [FromRoute] Guid id)
        {
            return _repository.FindRoomByFloor(id);
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
                _repository.Delete(room);
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