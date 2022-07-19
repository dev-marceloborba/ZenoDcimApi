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
    public class EquipmentController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public EquipmentController(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor/room/equipment")]
        [HttpPost]
        public async Task<ICommandResult> CreateEquipment(
          [FromBody] CreateEquipmentCommand command,
          [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEquipment(
          [FromRoute] Guid id,
          [FromBody] CreateEquipmentCommand command,
          [FromServices] BuildingHandler handler)
        {
            try
            {
                var equipment = await _repository.FindEquipmentById(id);
                equipment.Class = command.Class;
                equipment.Component = command.Component;
                equipment.ComponentCode = command.ComponentCode;
                equipment.Description = command.Description;
                equipment.Group = command.Group;
                equipment.TrackModifiedDate();
                _repository.UpdateEquipment(equipment);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Equipamento atualizado com sucesso", equipment));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar equipamento", new { id }));
            }
        }

        [Route("building/floor/room/equipment")]
        [HttpGet]
        public async Task<IEnumerable<Equipment>> FindAllEquipments()
        {
            return await _repository.FindAllEquipments();
        }

        [Route("building/floor/room/equipment/{id}")]
        [HttpGet]
        public async Task<Equipment> FindEquipmentById(Guid id)
        {
            return await _repository.FindEquipmentById(id);
        }

        [Route("building/floor/room/equipment/{id}")]
        [HttpDelete]
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
        public async Task<ICommandResult> CreateMultipleEquipments(
            [FromBody] CreateMultipleEquipmentsCommand command,
            [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }
    }
}