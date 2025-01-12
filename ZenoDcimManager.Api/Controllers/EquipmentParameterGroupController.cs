using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center")]
    [AllowAnonymous]
    public class EquipmentParameterGroupController : ControllerBase
    {
        private readonly IEquipmentParameterGroupRepository _repository;

        public EquipmentParameterGroupController(IEquipmentParameterGroupRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor/room/equipment/parameter/group")]
        [HttpPost]
        public async Task<ICommandResult> CreateEquipmentParameterGroup(
           [FromBody] CreateEquipmentParameterGroupCommand command,
           [FromServices] ParameterGroupHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/group/{id}")]
        [HttpPut]
        public async Task<IActionResult> EditEquipmentParameterGroup(
            [FromRoute] Guid id,
            [FromBody] CreateEquipmentParameterGroupCommand command,
            [FromServices] ParameterGroupHandler handler,
            [FromServices] ZenoContext context)
        {
            try
            {
                var parameterGroupAssignments = new List<ParameterGroupAssignment>();
                var equipmentParameterGroup = await _repository.FindByIdAsync(id);

                equipmentParameterGroup.Name = command.Name;

                foreach (var parameterId in command.ParametersId)
                {
                    parameterGroupAssignments.Add(new ParameterGroupAssignment
                    {
                        EquipmentParameterGroupId = equipmentParameterGroup.Id,
                        Parameter = await context.Parameters.Where(x => x.Id == parameterId).FirstOrDefaultAsync()
                    });
                }
                equipmentParameterGroup.ParameterGroupAssignments = parameterGroupAssignments;
                equipmentParameterGroup.TrackModifiedDate();

                _repository.Update(equipmentParameterGroup);
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
            return await _repository.FindAllAsync();
        }

        [Route("building/floor/room/equipment/parameter/group/{id}")]
        [HttpDelete]
        public ActionResult DeleteEquipmentParameterGroup(Guid id)
        {
            var parameterGroup = new EquipmentParameterGroup();
            parameterGroup.SetId(id);
            try
            {
                _repository.Delete(parameterGroup);
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