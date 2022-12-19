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
    [Route("v1/room-card-settings")]
    [AllowAnonymous]
    public class RoomCardSettingsController : ControllerBase
    {
        private readonly ZenoContext _context;

        public RoomCardSettingsController(ZenoContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> CreateAsync(
            [FromBody] RoomCardSettingsEditorCommand command
        )
        {
            var result = await _context.RoomCardSettings.AddAsync(
                new RoomCardSettings
                {
                    Parameter1 = command.Parameter1,
                    Parameter2 = command.Parameter2,
                    Parameter3 = command.Parameter3,
                    RoomId = command.RoomId
                }
            );

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> FindAllAsync()
        {
            var result = await _context.RoomCardSettings
                .AsNoTracking()
                .Include(x => x.Room)
                .Include(x => x.Parameter1)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter2)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter3)
                .ThenInclude(x => x.EquipmentParameter)
                .ToListAsync();
            return Ok(result);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(
            [FromRoute] Guid id,
            [FromBody] RoomCardSettingsEditorCommand command
        )
        {
            var cardSettings = await _context.RoomCardSettings.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (cardSettings != null)
            {
                cardSettings.Parameter1 = command.Parameter1;
                cardSettings.Parameter2 = command.Parameter2;
                cardSettings.Parameter3 = command.Parameter3;
                cardSettings.TrackModifiedDate();

                _context.Entry(cardSettings).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(cardSettings);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}