using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.UserContext.Commands.Input;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/user-preferencies")]
    [AllowAnonymous]
    public class UserPreferenciesController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult> FindPreferenceByUser(
            [FromRoute] Guid id,
            [FromServices] ZenoContext context
        )
        {
            var result = await context.Users
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.UserPreferencies)
                .Select(x => x.UserPreferencies)
                .FirstOrDefaultAsync();
            return Ok(result);
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> CreatePreferencies(
            [FromBody] UserPreferencesEditorCommand command,
            [FromServices] ZenoContext context
        )
        {
            var userPreferencies = new UserPreferencies
            {
                AvailableParameterTable = command.AvailableParameterTable,
                BuildingTable = command.BuildingTable,
                EquipmentParameterTable = command.EquipmentParameterTable,
                EquipmentTable = command.EquipmentTable,
                GroupParameterTable = command.GroupParameterTable,
                ParameterTable = command.ParameterTable,
                RoomTable = command.RoomTable,
                RuleTable = command.RuleTable,
                SiteTable = command.SiteTable,
                UserTable = command.UserTable,
                AlarmHistoryTable = command.AlarmHistoryTable,
            };

            await context.UserPreferencies.AddAsync(userPreferencies);
            await context.SaveChangesAsync();

            return Ok(userPreferencies);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdatePreferencies(
            [FromRoute] Guid id,
            [FromBody] UserPreferencesEditorCommand command,
            [FromServices] ZenoContext context
        )
        {
            var user = await context.Users
                .Where(x => x.Id == id)
                .Include(x => x.UserPreferencies)
                .FirstOrDefaultAsync();

            user.UserPreferencies.AvailableParameterTable = command.AvailableParameterTable;
            user.UserPreferencies.BuildingTable = command.BuildingTable;
            user.UserPreferencies.EquipmentParameterTable = command.EquipmentParameterTable;
            user.UserPreferencies.EquipmentTable = command.EquipmentTable;
            user.UserPreferencies.GroupParameterTable = command.GroupParameterTable;
            user.UserPreferencies.ParameterTable = command.ParameterTable;
            user.UserPreferencies.RoomTable = command.RoomTable;
            user.UserPreferencies.RuleTable = command.RuleTable;
            user.UserPreferencies.SiteTable = command.SiteTable;
            user.UserPreferencies.UserTable = command.UserTable;
            user.UserPreferencies.AlarmHistoryTable = command.AlarmHistoryTable;
            user.UserPreferencies.TrackModifiedDate();

            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok(user);
        }

    }
}