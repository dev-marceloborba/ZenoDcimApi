using System;
using System.Collections.Generic;
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
            alarm.AckInterval = (TimeSpan)(alarm.RecognizedDate - alarm.InDate);
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
            var alarmsStatistics = new AlarmStatisticsViewModel();
            var alarmRecognitionInterval = new List<AlarmRecognitionIntervalViewModel>();
            var alarmCategory = new List<AlarmGroupViewModel>();
            try
            {
                var alarms = await context.Alarms.Where(x => x.InDate >= initialDate && x.InDate <= finalDate).ToListAsync();
                var ackedAlarms = await context.Alarms.Where(x => x.RecognizedDate >= initialDate && x.RecognizedDate <= finalDate).ToListAsync();
                foreach (var item in ackedAlarms)
                {
                    alarmRecognitionInterval.Add(new AlarmRecognitionIntervalViewModel
                    {
                        Id = item.Id,
                        InDate = item.InDate,
                        OutDate = (DateTime)item.RecognizedDate,
                        Interval = (TimeSpan)(item.RecognizedDate - item.InDate)
                    });
                }

                foreach (var item in alarms)
                {
                    var arr = item.Pathname.Split('*');
                    alarmCategory.Add(new AlarmGroupViewModel
                    {
                        Id = item.Id,
                        // Site = arr[0],
                        // Building = arr[1],
                        // Floor = arr[2],
                        // Room = arr[3],
                        // Equipment = arr[4],
                        // Parameter = arr[5],
                        Pathname = arr[0] + '*' + arr[1] + '*' + arr[2] + '*' + arr[3] + '*' + arr[4]
                    });
                }

                var q = from p in alarmCategory
                        group p by p.Pathname into g
                        select new
                        {
                            Pathname = g.Key,
                            Total = g.Count()
                        };

                alarmsStatistics.MaxAckTime = Math.Round(alarmRecognitionInterval.Max(x => x.Interval.TotalHours), 2);
                alarmsStatistics.MinAckTime = Math.Round(alarmRecognitionInterval.Min(x => x.Interval.TotalHours), 2);
                alarmsStatistics.AverageAckTime = Math.Round(alarmRecognitionInterval.Average(x => x.Interval.TotalHours), 2);
                alarmsStatistics.AlarmsNotAcked = alarms.Where(x => x.Status != EAlarmStatus.ACKED && x.Status != EAlarmStatus.INACTIVE).Count();

                return Ok(new
                {
                    AverageAckTime = alarmsStatistics.AverageAckTime,
                    MaxAckTime = alarmsStatistics.MaxAckTime,
                    MinAckTime = alarmsStatistics.MinAckTime,
                    AlarmsNotAcked = alarmsStatistics.AlarmsNotAcked,
                    Categories = q.ToList(),
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}