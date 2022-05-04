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
    public class DataCenterController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public DataCenterController(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("site")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateSite(
            [FromBody] CreateSiteCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("site")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Site>> FindAllSites()
        {
            return await _repository.FindAllSites();
        }

        [Route("site")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteSite(Guid id)
        {
            try
            {
                var site = await _repository.FindSiteById(id);
                _repository.DeleteSite(site);
                await _repository.Commit();
                return Ok(site);
            }
            catch
            {
                return BadRequest();
            }
        }

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
        public async Task<IEnumerable<Building>> FindAllBuildings()
        {
            return await _repository.FindAllBuildings();
        }

        [Route("building/{Id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<Building> FindBuildingById(Guid Id)
        {
            return await _repository.FindBuildingById(Id);
        }


        [Route("building/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteBuilding(Guid Id)
        {
            try
            {
                _repository.DeleteBuilding(Id);
                _repository.Commit();
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
        public async Task<IEnumerable<Floor>> FindAllFloors()
        {
            return await _repository.FindAllFloors();
        }

        [Route("building/floor/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteFloor(Guid Id)
        {
            try
            {
                var floor = await _repository.FindFloorById(Id);
                _repository.DeleteFloor(floor);
                await _repository.Commit();
                return Ok(floor);
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
        public async Task<IEnumerable<Room>> FindAllRooms()
        {
            return await _repository.FindAllRooms();
        }

        [Route("building/floor/room/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteRoom(Guid Id)
        {
            try
            {
                var room = await _repository.FindRoomById(Id);
                _repository.DeleteRoom(room);
                await _repository.Commit();
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
        public async Task<IEnumerable<Equipment>> FindAllEquipments()
        {
            return await _repository.FindAllEquipments();
        }

        [Route("building/floor/room/equipment/{Id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<Equipment> FindEquipmentById(Guid Id)
        {
            return await _repository.FindEquipmentById(Id);
        }

        [Route("building/floor/room/equipment/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteEquipment(Guid Id)
        {
            try
            {
                var equipment = await _repository.FindEquipmentById(Id);
                _repository.DeleteEquipment(equipment);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room/equipment/multiple")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateMultipleEquipments(
            [FromBody] CreateMultipleEquipmentsCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateEquipmentParameter(
            [FromBody] CreateEquipmentParameterCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/multiple")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateMultipleEquipmentParameter(
        [FromBody] CreateMultipleParametersCommand command,
        [FromServices] BuildingHandler handler
    )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteEquipmentParameter(Guid Id)
        {
            try
            {
                var parameter = await _repository.FindEquipmentParameterById(Id);
                _repository.DeleteEquipmentParameter(parameter);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room/equipment/parameter/{Id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<EquipmentParameter> FindEquipmentParameterById(Guid Id)
        {
            return await _repository.FindEquipmentParameterById(Id);
        }

        [Route("building/floor/room/equipmentParameterById/{Id}")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid Id)
        {
            return _repository.FindParametersByEquipmentId(Id);
        }

        // Equipment parameter group
        [Route("building/floor/room/equipment/parameter/group")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateEquipmentParameterGroup(
            [FromBody] CreateEquipmentParameterGroupCommand command,
            [FromServices] BuildingHandler handler
            )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/group")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<EquipmentParameterGroup>> FindAllEquipmentParameterGroups()
        {
            return await _repository.FindAllEquipmentParameterGroups();
        }

        [Route("building/floor/room/equipment/parameters")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<EquipmentParameter>> FindAllEquipmentParameters()
        {
            return await _repository.FindAllEquipmentParameters();
        }

        [Route("parameters")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateParameter(
            [FromBody] CreateParameterCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return await handler.Handle(command);
        }

        [Route("parameters")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Parameter>> FindAllParameters()
        {
            return await _repository.FindAllParameters();
        }

        [Route("parameters/{Id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteParameter(Guid Id)
        {
            try
            {
                var parameter = await _repository.FindParameterById(Id);
                _repository.DeleteParameter(parameter);
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