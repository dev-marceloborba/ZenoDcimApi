using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Api.Controllers.SiteBuildingCardSettingsController
{
    [ApiController]
    [Route("v1/building-card-settings")]
    [AllowAnonymous]
    public class BuildingCardSettingsController : ControllerBase
    {
        private readonly ZenoContext _context;

        public BuildingCardSettingsController(ZenoContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] BuildingCardSettingsEditorCommand command
        )
        {
            var result = await _context.BuildingCardSettings.AddAsync(
                new BuildingCardSettings
                {
                    BuildingId = command.BuildingId,
                    Parameter1 = command.Parameter1,
                    Parameter2 = command.Parameter2,
                    Parameter3 = command.Parameter3,
                    Parameter4 = command.Parameter4,
                    Parameter5 = command.Parameter5,
                    Parameter6 = command.Parameter6,
                }
            );
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> FindAllAsync()
        {
            var result = await _context.BuildingCardSettings
                .AsNoTracking()
                .Include(x => x.Building)
                .Include(x => x.Parameter1)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter2)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter3)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter4)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter5)
                .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.Parameter6)
                .ThenInclude(x => x.EquipmentParameter)
                .ToListAsync();
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] BuildingCardSettingsEditorCommand command
        )
        {
            var result = await _context.BuildingCardSettings.FirstOrDefaultAsync(x => x.Id == id);

            result.Parameter1 = command.Parameter1;
            result.Parameter2 = command.Parameter2;
            result.Parameter3 = command.Parameter3;
            result.Parameter4 = command.Parameter4;
            result.Parameter5 = command.Parameter5;
            result.Parameter6 = command.Parameter6;

            result.TrackModifiedDate();

            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(result);
        }
    }
}