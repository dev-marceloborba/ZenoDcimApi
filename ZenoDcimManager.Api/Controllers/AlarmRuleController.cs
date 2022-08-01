using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center/alarm-rules")]
    [AllowAnonymous]
    public class AlarmRuleController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAlarmRule(
            [FromBody] CreateAlarmRuleCommand command,
            [FromServices] AlarmRuleHandler handler)
        {
            var result = await handler.Handle(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> FindAllAlarmRules(
            [FromServices] IAlarmRuleRepository repository)
        {
            var result = await repository.FindAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindAlarmRuleById(
            [FromRoute] Guid id,
            [FromServices] IAlarmRuleRepository repository)
        {
            var result = await repository.FindByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAlarmRule(
            [FromRoute] Guid id,
            [FromBody] CreateAlarmRuleCommand command,
            [FromServices] IAlarmRuleRepository repository)
        {
            var alarmRule = await repository.FindByIdAsync(id);
            alarmRule.Name = command.Name;
            alarmRule.Conditional = command.Conditional;
            alarmRule.EquipmentParameterId = command.EquipmentParameterId;
            alarmRule.Priority = command.Priority;
            alarmRule.Setpoint = command.Setpoint;
            alarmRule.TrackModifiedDate();

            repository.Update(alarmRule);
            await repository.Commit();

            return Ok(new CommandResult(true, "Regra de alarme alterada com sucesso", alarmRule));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAlarmRule(
            [FromRoute] Guid id,
            [FromServices] IAlarmRuleRepository repository)
        {
            var alarm = new AlarmRule();
            alarm.SetId(id);

            repository.Delete(alarm);
            await repository.Commit();

            return Ok(alarm);
        }
    }
}