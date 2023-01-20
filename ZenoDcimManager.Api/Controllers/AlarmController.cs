using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Api.Hubs;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Hubs;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Infra.Contexts;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/alarms")]
    [AllowAnonymous]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmRepository _repository;
        private readonly IHubContext<NotificationsHub, INotificationClient> _hubContext;
        private readonly AlarmEmailHandler _emailHandler;

        public AlarmController(IAlarmRepository repository, IHubContext<NotificationsHub, INotificationClient> hubContext, AlarmEmailHandler emailHandler)
        {
            _repository = repository;
            _hubContext = hubContext;
            _emailHandler = emailHandler;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] CreateAlarmCommand command,
            [FromServices] ZenoContext context
        )
        {
            var alarm = new Alarm
            {
                Pathname = command.Pathname,
                Value = command.Value,
                Enabled = command.Enabled,
                Status = command.Status,
                AlarmRuleId = command.AlarmRuleId,
                InDate = command.InDate,
                OutDate = command.OutDate,
                NotificationEnabled = command.NotificationEnabled,
                EmailEnabled = command.EmailEnabled,
                Type = command.Type,
            };

            if (alarm.NotificationEnabled == true)
            {
                await _hubContext.Clients.All.SendAlarmNotification(alarm);
            }

            if (alarm.EmailEnabled == true)
            {
                await _emailHandler.Handle(alarm.Pathname);
            }

            await _repository.CreateAsync(alarm);
            await _repository.Commit();

            return Ok(new CommandResult(true, "Alarme criado com sucesso", alarm));
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
            [FromQuery] DateTime finalDate,
            [FromQuery] int priority,
            [FromQuery] int type)
        {
            // var result = await _repository.GetFilteredAlarms(new AlarmFiltersViewModel
            // {
            //     InitialDate = initialDate,
            //     FinalDate = finalDate
            // });

            // type = 4: filtra tipo = 0 e tipo = 1 ou remove filtro por tipo.
            // type = 0: filtra tipo = 0
            // type = 1: filtra tipo = 1

            // priority = 4, filtra severidade tipo 0, 1, e 2 ou remove filtro
            // priority = 0 filtra severidade tipo 0
            // priority = 1 filtra severidade tipo 1
            // priority = 2 filtra severidade tipo 2

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
                    },
                    x.Priority,
                    x.Type
                })
                .Where(x => x.CreatedDate >= initialDate && x.CreatedDate <= finalDate
                        && (priority == 4 ? x.Priority >= 0 : x.Priority == (EAlarmPriority)priority)
                        && (type == 4 ? x.Type >= 0 : x.Type == (EAlarmType)type)
                )
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
                // var ackedAlarms = await context.Alarms.Where(x => x.RecognizedDate >= initialDate && x.RecognizedDate <= finalDate).ToListAsync();
                var ackedAlarms = alarms.Where(x => x.RecognizedDate >= initialDate && x.RecognizedDate <= finalDate).ToList();
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
                        // Pathname = arr[0] + '*' + arr[1] + '*' + arr[2] + '*' + arr[3] + '*' + arr[4]
                        Pathname = string.Join("*", arr)
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
                    Categories = q.ToList().Take(10),
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}