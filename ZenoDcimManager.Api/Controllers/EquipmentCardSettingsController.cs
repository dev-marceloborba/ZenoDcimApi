using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
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
            [FromBody] EquipmentCardSettingsEditorCommand command
        )
        {
            var result = await _context.EquipmentCardSettings.AddAsync(
                new EquipmentCardSettings
                {
                    EquipmentId = command.EquipmentId,
                    Parameter1 = command.Parameter1,
                    Parameter2 = command.Parameter2,
                    Parameter3 = command.Parameter3
                }
            );
            await _context.SaveChangesAsync();
            return Ok();
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