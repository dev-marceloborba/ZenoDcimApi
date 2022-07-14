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
        public async Task<ICommandResult> CreateSite(
            [FromBody] CreateSiteCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
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
                var site = new Site();
                site.SetId(id);
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
        public async Task<ICommandResult> CreateBuilding(
            [FromBody] CreateBuildingCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Building>> FindAllBuildings()
        {
            return await _repository.FindAllBuildings();
        }

        [Route("building/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<Building> FindBuildingById(Guid id)
        {
            return await _repository.FindBuildingById(id);
        }


        [Route("building/{id}")]
        [HttpDelete]
        [AllowAnonymous]
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

        [Route("building/floor")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateFloor(
            [FromBody] CreateFloorCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Floor>> FindAllFloors()
        {
            return await _repository.FindAllFloors();
        }

        [Route("building/floor/{id}")]
        [HttpDelete]
        [AllowAnonymous]
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

        [Route("building/floor/room")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateRoom(
            [FromBody] CreateRoomCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Room>> FindAllRooms()
        {
            return await _repository.FindAllRooms();
        }

        [Route("building/floor/room/{id}")]
        [HttpGet]
        [AllowAnonymous]
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

        [Route("building/floor/room/equipment")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateEquipment(
            [FromBody] CreateEquipmentCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Equipment>> FindAllEquipments()
        {
            return await _repository.FindAllEquipments();
        }

        [Route("building/floor/room/equipment/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<Equipment> FindEquipmentById(Guid id)
        {
            return await _repository.FindEquipmentById(id);
        }

        [Route("building/floor/room/equipment/{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteEquipment(Guid id)
        {
            try
            {
                var equipment = new Equipment();
                equipment.SetId(id);
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
        public async Task<ICommandResult> CreateMultipleEquipments(
            [FromBody] CreateMultipleEquipmentsCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateEquipmentParameter(
            [FromBody] CreateEquipmentParameterCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/multiple")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateMultipleEquipmentParameter(
        [FromBody] CreateMultipleParametersCommand command,
        [FromServices] BuildingHandler handler
    )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteEquipmentParameter(Guid id)
        {
            try
            {
                var parameter = new EquipmentParameter();
                parameter.SetId(id);
                _repository.DeleteEquipmentParameter(parameter);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<EquipmentParameter> FindEquipmentParameterById(Guid id)
        {
            return await _repository.FindEquipmentParameterById(id);
        }

        [Route("building/floor/room/equipmentParameterById/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id)
        {
            return _repository.FindParametersByEquipmentId(id);
        }

        // Equipment parameter group
        [Route("building/floor/room/equipment/parameter/group")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateEquipmentParameterGroup(
            [FromBody] CreateEquipmentParameterGroupCommand command,
            [FromServices] BuildingHandler handler
            )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/group/{id}")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> EditEquipmentParameterGroup(
            [FromRoute] Guid id,
            [FromBody] CreateEquipmentParameterGroupCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var equipmentParameterGroup = await _repository.FindEquipmentParameterGroupById(id);
                equipmentParameterGroup.Name = command.Name;
                _repository.UpdateParameterGroup(equipmentParameterGroup);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Grupo editado com sucesso", equipmentParameterGroup));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao editar grupo", command));
            }
        }

        [Route("building/floor/room/equipment/parameter/group")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<EquipmentParameterGroup>> FindAllEquipmentParameterGroups()
        {
            return await _repository.FindAllEquipmentParameterGroups();
        }

        [Route("building/floor/room/equipment/parameter/group/{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteEquipmentParameterGroup(Guid id)
        {
            var parameterGroup = new EquipmentParameterGroup();
            parameterGroup.SetId(id);
            try
            {
                _repository.DeleteParameterGroup(parameterGroup);
                _repository.Commit();
                return Ok(parameterGroup);
            }
            catch
            {
                return BadRequest(parameterGroup);
            }
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
            return (ICommandResult)await handler.Handle(command);
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
        public async Task<ActionResult> DeleteParameter(Guid id)
        {
            try
            {
                var parameter = await _repository.FindParameterById(id);
                _repository.DeleteParameter(parameter);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        //[Route("parametersByGroup/{id}")]
        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IEnumerable<Parameter>> FindParametersByGroupd(Guid groupId)
        //{
        //    return await _repository.FindParametersByGroup(groupId);
        //}

        [Route("parametersByGroup/{group}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Parameter>> FindParametersByGroupd(string group)
        {
            return await _repository.FindParametersByGroup(group);
        }

        [Route("parameters/groupAssociation")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateEquipmentOnGroup(
            [FromServices] BuildingHandler handler,
            [FromBody] CreateEquipmentOnGroupCommand command
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }
    }
}