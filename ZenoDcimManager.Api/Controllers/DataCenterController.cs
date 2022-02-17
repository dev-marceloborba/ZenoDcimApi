using System;
using System.Collections.Generic;
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
    public class DataCenterController : ControllerBase
    {
        [Route("building")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateBuilding(
            [FromBody] CreateBuildingCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Building> FindAllBuildings(
            [FromServices] IDataCenterRepository repository
        )
        {
            return repository.FindAllBuildings();
        }

        [Route("building/{Id}")]
        [HttpGet]
        [AllowAnonymous]
        public Building FindBuildingById(
            Guid Id,
            [FromServices] IDataCenterRepository repository
        )
        {
            return repository.FindBuildingById(Id);
        }


        [Route("building/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteBuilding(
            Guid Id,
            [FromServices] IDataCenterRepository repository
        )
        {
            try
            {
                repository.DeleteBuilding(Id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateFloor(
            [FromBody] CreateFloorCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Floor> FindAllFloors(
            [FromServices] IDataCenterRepository repository
        )
        {
            return repository.FindAllFloors();
        }

        [Route("building/floor/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteFloor(
            Guid Id,
            [FromServices] IDataCenterRepository repository
        )
        {
            try
            {
                var floor = repository.FindFloorById(Id);
                repository.DeleteFloor(floor);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateRoom(
            [FromBody] CreateRoomCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor/room")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Room> FindAllRooms(
            [FromServices] IDataCenterRepository repository
        )
        {
            return repository.FindAllRooms();
        }

        [Route("building/floor/room/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteRoom(
            Guid Id,
            [FromServices] IDataCenterRepository repository
        )
        {
            try
            {
                var room = repository.FindRoomById(Id);
                repository.DeleteRoom(room);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room/equipment")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateEquipment(
            [FromBody] CreateEquipmentCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor/room/equipment")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Equipment> FindAllEquipments(
            [FromServices] IDataCenterRepository repository
        )
        {
            return repository.FindAllEquipments();
        }

        [Route("building/floor/room/equipment/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteEquipment(
            Guid Id,
            [FromServices] IDataCenterRepository repository
        )
        {
            try
            {
                var equipment = repository.FindEquipmentById(Id);
                repository.DeleteEquipment(equipment);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}