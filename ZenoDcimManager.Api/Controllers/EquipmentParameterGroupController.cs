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
    public class EquipmentParameterGroupController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public EquipmentParameterGroupController(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor/room/equipment/parameter/group")]
        [HttpPost]
        public async Task<ICommandResult> CreateEquipmentParameterGroup(
           [FromBody] CreateEquipmentParameterGroupCommand command,
           [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/group/{id}")]
        [HttpPut]
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
        public async Task<IEnumerable<EquipmentParameterGroup>> FindAllEquipmentParameterGroups()
        {
            return await _repository.FindAllEquipmentParameterGroups();
        }

        [Route("building/floor/room/equipment/parameter/group/{id}")]
        [HttpDelete]
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
    }
}