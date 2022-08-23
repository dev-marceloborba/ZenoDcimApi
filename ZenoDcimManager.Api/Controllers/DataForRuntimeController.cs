using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/runtime")]
    [AllowAnonymous]
    public class DataForRuntimeController : ControllerBase
    {
        private readonly ZenoContext _context;

        public DataForRuntimeController(ZenoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetTaskAsync()
        {
            var result = await _context.Buildings
                .Include(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .ThenInclude(x => x.Equipments)
                .ThenInclude(x => x.EquipmentParameters)
                .Select(x => new
                {
                    Building = x.Name,
                    Floors = x.Floors.Select(f => new
                    {
                        Name = f.Name,
                        Rooms = f.Rooms.Select(r => new
                        {
                            Name = r.Name,
                            Equipments = r.Equipments.Select(e => new
                            {
                                Name = e.Component,
                                Parameters = e.EquipmentParameters.Select(p => new
                                {
                                    Name = p.Name,
                                    Expression = p.Expression
                                })
                            })
                        })
                    })
                })
                .ToListAsync();
            return Ok(result);
        }
    }
}