using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/alarms")]
    [AllowAnonymous]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmRepository _repository;

        public AlarmController(IAlarmRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] CreateAlarmCommand command,
            [FromServices] AlarmHandler handler
        )
        {
            var result = await handler.Handle(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("ack")]
        public async Task<ActionResult> Ack([FromBody] Guid alarmId)
        {
            var alarm = await _repository.FindByIdAsync(alarmId);
            alarm.Status = EAlarmStatus.ACKED;
            _repository.Update(alarm);
            await _repository.Commit();
            return Ok(alarm);
        }

        [HttpPost]
        [Route("inactive")]
        public async Task<ActionResult> Inactive([FromBody] Guid alarmId)
        {
            var alarm = await _repository.FindByIdAsync(alarmId);
            alarm.Status = EAlarmStatus.INACTIVE;
            _repository.Update(alarm);
            await _repository.Commit();
            return Ok(alarm);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetFilteredAlarms(
            [FromServices] ZenoContext context,
            [FromQuery] DateTime initialDate,
            [FromQuery] DateTime finalDate)
        {
            // var result = await _repository.GetFilteredAlarms(new AlarmFiltersViewModel
            // {
            //     InitialDate = initialDate,
            //     FinalDate = finalDate
            // });
            var result = await context.Alarms
                .AsNoTracking()
                .Include(x => x.AlarmRule)
                .Select(x => new
                {
                    x.Value,
                    x.Status,
                    x.Enabled,
                    x.Id,
                    x.CreatedDate,
                    AlarmRule = new
                    {
                        Id = x.AlarmRule.Id,
                        Name = x.AlarmRule.Name,
                        Setpoint = x.AlarmRule.Setpoint,
                        Priority = x.AlarmRule.Priority,
                        EquipmentParameter = new
                        {
                            Id = x.AlarmRule.EquipmentParameter.Id,
                            Name = x.AlarmRule.EquipmentParameter.Name,
                            Equipment = new
                            {
                                Id = x.AlarmRule.EquipmentParameter.Equipment.Id,
                                Name = x.AlarmRule.EquipmentParameter.Equipment.Component,
                                Room = new
                                {
                                    Id = x.AlarmRule.EquipmentParameter.Equipment.Room.Id,
                                    Name = x.AlarmRule.EquipmentParameter.Equipment.Room.Name,
                                    Floor = new
                                    {
                                        Id = x.AlarmRule.EquipmentParameter.Equipment.Floor.Id,
                                        Name = x.AlarmRule.EquipmentParameter.Equipment.Floor.Name,
                                        Building = new
                                        {
                                            Id = x.AlarmRule.EquipmentParameter.Equipment.Floor.Building.Id,
                                            Name = x.AlarmRule.EquipmentParameter.Equipment.Floor.Building.Name
                                        }
                                    }
                                },

                            }
                        }
                    }
                })
                .Where(x => x.CreatedDate >= initialDate && x.CreatedDate <= finalDate)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var alarm = new Alarm();
                alarm.SetId(id);

                _repository.Delete(alarm);
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