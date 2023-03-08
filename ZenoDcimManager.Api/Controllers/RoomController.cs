using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Commands.Outputs;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/data-center/building/floor/room")]
    [AllowAnonymous]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _repository;

        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }
        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreateRoom(
           [FromBody] CreateRoomCommand command,
           [FromServices] RoomHandler handler
       )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("{id}")]
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
                room.RackCapacity = command.RackCapacity;
                room.PowerCapacity = command.PowerCapacity;
                room.FloorId = command.FloorId;
                room.BuildingId = command.BuildingId;
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

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Room>> FindAllRooms()
        {
            return await _repository.FindAllAsync();
        }

        [Route("{id}")]
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

        [Route("{id}")]
        [HttpDelete]
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

        [Route("load-cards/{buildingId}")]
        [HttpGet]
        public async Task<ActionResult> LoadRoomCards(
            [FromRoute] Guid buildingId,
            [FromServices] ZenoContext context
        )
        {
            var result = await _repository.LoadCardSettings(buildingId);
            return Ok(result);
        }

        [Route("occupation-card/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetOccupationCard(
            [FromRoute] Guid id,
            [FromServices] ZenoContext context
        )
        {
            var output = new List<OccupiedOutput>();
            var rooms = await context.Rooms
                .AsNoTracking()
                .Where(x => x.BuildingId == id)
                    .Include(x => x.Racks)
                    .ThenInclude(x => x.RackEquipments)
                .OrderBy(x => x.Name)
                .ToListAsync();


            foreach (var room in rooms)
            {
                output.Add(new OccupiedOutput
                {
                    Id = room.Id,
                    Name = room.Name,
                    PowerCapacity = room.PowerCapacity,
                    RackCapacity = room.RackCapacity,
                    OccupiedPower = room.GetOccupiedPower(),
                    OccupiedCapacity = room.GetOccupiedCapacity(),
                    RacksQuantity = room.GetRacksQuantity(),
                    RoomsQuantity = rooms.Count
                });
            }

            return Ok(output.Where(x => x.RackCapacity > 0));
        }
    }
}