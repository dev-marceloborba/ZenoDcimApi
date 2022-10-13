using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.UserContext.Commands.Input;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
// using ZenoDcimManager.Domain.UserContext.ValueObjects;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/groups")]
    [AllowAnonymous]
    public class GroupController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] CreateGroupCommand command,
            [FromServices] IGroupRepository repository
        )
        {
            var group = new Group
            {
                Name = command.Name,
                Description = command.Description,
                ActionAckAlarms = command.Actions.AckAlarms,
                ActionEditConnections = command.Actions.EditConnections,
                RegisterAlarms = command.Registers.Alarms,
                RegisterDatacenter = command.Registers.Datacenter,
                RegisterNotifications = command.Registers.Notifications,
                RegisterParameters = command.Registers.Parameters,
                RegisterUsers = command.Registers.Users,
                ViewAlarms = command.Views.Alarms,
                ViewEquipments = command.Views.Equipments,
                ViewParameters = command.Views.Parameters,
                ReceiveEmail = command.General.ReceiveEmail
            };

            await repository.CreateAsync(group);
            await repository.Commit();

            return Ok(group);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> FindAllAsync(
            [FromServices] IGroupRepository repository
        )
        {
            var result = await repository.FindAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> FindByIdAsync(
           [FromRoute] Guid id,
           [FromServices] IGroupRepository repository
       )
        {
            var result = await repository.FindByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] CreateGroupCommand command,
            [FromServices] IGroupRepository repository
        )
        {
            var group = await repository.FindByIdAsync(id);
            group.Name = command.Name;
            group.Description = command.Description;
            group.ActionAckAlarms = command.Actions.AckAlarms;
            group.ActionEditConnections = command.Actions.EditConnections;
            group.RegisterAlarms = command.Registers.Alarms;
            group.RegisterDatacenter = command.Registers.Datacenter;
            group.RegisterNotifications = command.Registers.Notifications;
            group.RegisterParameters = command.Registers.Parameters;
            group.RegisterUsers = command.Registers.Users;
            group.ViewAlarms = command.Views.Alarms;
            group.ViewEquipments = command.Views.Equipments;
            group.ViewParameters = command.Views.Parameters;
            group.ReceiveEmail = command.General.ReceiveEmail;
            group.TrackModifiedDate();

            repository.Update(group);
            await repository.Commit();

            return Ok(group);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] IGroupRepository repository)
        {
            var group = new Group();
            group.SetId(id);

            repository.Delete(group);
            await repository.Commit();
            return Ok(group);
        }
    }
}