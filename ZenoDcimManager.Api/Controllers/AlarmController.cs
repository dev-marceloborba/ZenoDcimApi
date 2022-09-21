using System;
using System.Collections.Generic;
using System.Globalization;
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

        [HttpPut]
        [Route("ack")]
        public async Task<ActionResult> Ack([FromBody] RecognizeAlarmCommand command)
        {
            var alarm = await _repository.FindByIdAsync(command.AlarmId);
            alarm.Status = EAlarmStatus.ACKED;
            alarm.RecognizedDate = command.RecognizedDate;
            _repository.Update(alarm);
            await _repository.Commit();
            return Ok(alarm);
        }

        [HttpPut]
        [Route("inactive")]
        public async Task<ActionResult> Inactive([FromBody] InactiveAlarmCommand command)
        {
            var alarm = await _repository.FindByIdAsync(command.Id);
            alarm.OutDate = command.OutDate;
            alarm.Value = command.Value;
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
                    x.Pathname,
                    x.Value,
                    x.Status,
                    x.Enabled,
                    x.Id,
                    x.CreatedDate,
                    x.InDate,
                    x.OutDate,
                    x.RecognizedDate,
                    AlarmRule = new
                    {
                        Id = x.AlarmRule.Id,
                        Name = x.AlarmRule.Name,
                        Setpoint = x.AlarmRule.Setpoint,
                        Priority = x.AlarmRule.Priority,
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

        [HttpGet]
        [Route("statistics")]
        public async Task<ActionResult> GetAlarmsStatistics(
            [FromServices] ZenoContext context,
            [FromQuery] DateTime initialDate,
            [FromQuery] DateTime finalDate)
        {
            var alarmRecognitionInterval = new List<AlarmRecognitionIntervalViewModel>();
            var alarmsStatistics = new AlarmStatisticsViewModel();

            var alarms = await context.Alarms.Where(x => x.InDate >= initialDate && x.OutDate <= finalDate).ToListAsync();

            try
            {
                foreach (var item in alarms)
                {
                    alarmRecognitionInterval.Add(new AlarmRecognitionIntervalViewModel
                    {
                        Id = item.Id,
                        InDate = item.InDate,
                        OutDate = (DateTime)item.OutDate,
                        Interval = (TimeSpan)(item.OutDate - item.InDate)
                    });
                }

                alarmsStatistics.MaxAckTime = Math.Round(alarmRecognitionInterval.Max(x => x.Interval.TotalHours), 2);
                alarmsStatistics.MinAckTime = Math.Round(alarmRecognitionInterval.Min(x => x.Interval.TotalHours), 2);
                alarmsStatistics.AverageAckTime = Math.Round(alarmRecognitionInterval.Average(x => x.Interval.TotalHours), 2);
                alarmsStatistics.AlarmsNotAcked = alarms.Where(x => x.Status != EAlarmStatus.ACKED && x.Status != EAlarmStatus.INACTIVE).Count();

                return Ok(alarmsStatistics);
            }
            catch
            {
                return BadRequest(alarmsStatistics);
            }

        }
    }
}