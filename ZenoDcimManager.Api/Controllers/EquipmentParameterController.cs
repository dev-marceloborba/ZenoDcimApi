using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Commands.Outputs;
using ZenoDcimManager.Domain.AutomationContext.Entities;
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
    public class EquipmentParameterControler : ControllerBase
    {
        private readonly IEquipmentParameterRepository _repository;

        public EquipmentParameterControler(IEquipmentParameterRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor/room/equipment/parameter")]
        [HttpPost]
        public async Task<ICommandResult> CreateEquipmentParameter(
          [FromBody] CreateEquipmentParameterCommand command,
          [FromServices] EquipmentParameterHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEquipmentParameter(
            [FromRoute] Guid id,
            [FromBody] CreateEquipmentParameterCommand command,
            [FromServices] ZenoContext context,
            [FromServices] EquipmentParameterHandler handler)
        {

            var newRules = command.AlarmRules.Where(x => x.Id == Guid.Empty);
            var updatedRules = command.AlarmRules.Where(x => x.Id != Guid.Empty);
            var deletedRules = new List<AlarmRule>();

            var equipmentParameter = await _repository.FindByIdWithoutTracking(id);

            foreach (var rule in equipmentParameter.AlarmRules)
            {
                if (command.AlarmRules.FirstOrDefault(x => x.Id == rule.Id) == null)
                {
                    var ruleToDelete = new AlarmRule();
                    ruleToDelete.SetId(rule.Id);
                    deletedRules.Add(ruleToDelete);
                }
            }

            foreach (var rule in newRules)
            {
                var ruleToInsert = new AlarmRule();
                ruleToInsert.EnableEmail = rule.EnableEmail;
                ruleToInsert.EnableNotification = rule.EnableNotification;
                ruleToInsert.EquipmentParameterId = equipmentParameter.Id;
                ruleToInsert.Name = rule.Name;
                ruleToInsert.Priority = rule.Priority;
                ruleToInsert.Setpoint = rule.Setpoint;
                ruleToInsert.Conditional = rule.Conditional;
                ruleToInsert.Type = rule.Type;
                await context.AlarmRules.AddAsync(ruleToInsert);
            }

            foreach (var rule in updatedRules)
            {
                var ruleToUpdate = await context.AlarmRules.FindAsync(rule.Id);
                ruleToUpdate.EnableEmail = rule.EnableEmail;
                ruleToUpdate.EnableNotification = rule.EnableNotification;
                ruleToUpdate.EquipmentParameterId = equipmentParameter.Id;
                ruleToUpdate.Name = rule.Name;
                ruleToUpdate.Priority = rule.Priority;
                ruleToUpdate.Setpoint = rule.Setpoint;
                ruleToUpdate.Type = rule.Type;
                ruleToUpdate.Conditional = rule.Conditional;
                ruleToUpdate.TrackModifiedDate();
                context.AlarmRules.Update(ruleToUpdate);
            }

            foreach (var rule in deletedRules)
            {
                context.Remove(rule);
            }

            equipmentParameter.DataSource = command.DataSource;
            equipmentParameter.Unit = command.Unit;
            equipmentParameter.Scale = command.Scale;
            equipmentParameter.ModbusTagName = command.Address;

            equipmentParameter.TrackModifiedDate();


            _repository.Update(equipmentParameter);
            await context.SaveChangesAsync();
            return Ok(new CommandResult(true, "Parâmetro de equipamento atualizado com sucesso", equipmentParameter));

        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpGet]
        public async Task<ActionResult> FindEquipmentParameterById(
            [FromRoute] Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEquipmentParameter(Guid id)
        {
            try
            {
                var parameter = new EquipmentParameter();
                parameter.SetId(id);
                _repository.Delete(parameter);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room/equipment/parameter/multiple")]
        [HttpPost]
        public async Task<ICommandResult> CreateMultipleEquipmentParameter(
            [FromBody] CreateMultipleParametersCommand command,
            [FromServices] EquipmentParameterHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipmentParameterById/{id}")]
        [HttpGet]
        public ActionResult FindParametersByEquipmentId(Guid id)
        {
            var parameters = new List<FindParametersByEquipmentOutputCommand>();
            var result = _repository.FindParametersByEquipmentId(id);
            foreach (var item in result)
            {
                var pathname = item.GetPathname();
                parameters.Add(new FindParametersByEquipmentOutputCommand
                {
                    Id = item.Id,
                    Name = item.Name,
                    Unit = item.Unit,
                    Scale = item.Scale,
                    DataSource = item.DataSource,
                    Expression = item.Expression,
                    EquipmentId = item.EquipmentId,
                    Equipment = item.Equipment,
                    ModbusTagName = item.ModbusTagName,
                    Data = item.Data,
                    AlarmRules = item.AlarmRules,
                    Pathname = pathname
                });
            }
            return Ok(parameters);
        }

        [Route("building/floor/room/equipment/parameters")]
        [HttpGet]
        public async Task<IEnumerable<EquipmentParameter>> FindAllEquipmentParameters()
        {
            return await _repository.FindAllAsync();
        }
    }
}