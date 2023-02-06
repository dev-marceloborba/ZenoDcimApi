using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/equipment-card-settings")]
    [AllowAnonymous]
    public class EquipmentCardSettingsController : ControllerBase
    {
        private readonly ZenoContext _context;

        public EquipmentCardSettingsController(ZenoContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> CreateAsync(
            [FromBody] EquipmentCardSettingsEditorCommand command,
            [FromServices] EquipmentCardHandler handler
        )
        {
            var result = await handler.Handle(command);
            return Ok(result);
        }

        [Route("{equipmentId}")]
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(
            [FromRoute] Guid equipmentId,
            [FromBody] EquipmentCardSettingsEditorCommand command
        )
        {
            var cardSettings = await _context.EquipmentCardSettings.Where(x => x.Id == equipmentId).FirstOrDefaultAsync();
            if (cardSettings != null)
            {
                cardSettings.Parameter1 = command.Parameter1;
                cardSettings.Parameter2 = command.Parameter2;
                cardSettings.Parameter3 = command.Parameter3;
                cardSettings.TrackModifiedDate();

                _context.Entry(cardSettings).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}