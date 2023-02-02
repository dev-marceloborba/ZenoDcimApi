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
        public async Task<ActionResult> GetDataCenterStructure()
        {
            var result = await _context.Sites
                .Include(x => x.Buildings)
                .ThenInclude(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .ThenInclude(x => x.Equipments)
                .ThenInclude(x => x.EquipmentParameters)
                .ThenInclude(x => x.AlarmRules)
                .Select(s => new
                {
                    Name = s.Name,
                    Buildings = s.Buildings.Select(b => new
                    {
                        Name = b.Name,
                        Floors = b.Floors.Select(f => new
                        {
                            Name = f.Name,
                            Rooms = f.Rooms.Select(r => new
                            {
                                Name = r.Name,
                                Equipments = r.Equipments.Select(e => new
                                {
                                    Name = e.Component,
                                    Parameters = e.EquipmentParameters.Select(ep => new
                                    {
                                        Name = ep.Name,
                                        Unit = ep.Unit,
                                        Expression = ep.Expression,
                                        AlarmRules = ep.AlarmRules.Select(ar => new
                                        {
                                            ar.Id,
                                            ar.Name,
                                            ar.Priority,
                                            ar.Conditional,
                                            ar.Setpoint,
                                            ar.EnableNotification,
                                            ar.EnableEmail,
                                            ar.Type
                                        })
                                    })
                                })
                            })
                        })
                    })
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("alarms")]
        public async Task<ActionResult> GetAlarmsConfiguration()
        {
            var result = await _context.AlarmRules
                .AsNoTracking()
                .Include(x => x.EquipmentParameter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Priority,
                    x.Conditional,
                    x.Setpoint,
                    x.EnableNotification,
                    x.EnableEmail,
                    x.Type,
                    EquipmentParameter = x.EquipmentParameter.Name,
                    Equipment = x.EquipmentParameter.Equipment.Component,
                    Room = x.EquipmentParameter.Equipment.Room.Name,
                    Floor = x.EquipmentParameter.Equipment.Room.Floor.Name,
                    Building = x.EquipmentParameter.Equipment.Room.Floor.Building.Name,
                    Site = x.EquipmentParameter.Equipment.Room.Floor.Building.Site.Name
                    // EquipmentParameter = new
                    // {
                    //     Name = x.EquipmentParameter.Name,
                    //     Equipment = new
                    //     {
                    //         Name = x.EquipmentParameter.Equipment.Component,
                    //         Room = new
                    //         {
                    //             Name = x.EquipmentParameter.Equipment.Room.Name,
                    //             Floor = new
                    //             {
                    //                 Name = x.EquipmentParameter.Equipment.Room.Floor.Name,
                    //                 Building = new
                    //                 {
                    //                     Name = x.EquipmentParameter.Equipment.Room.Floor.Building.Name,
                    //                     Site = new
                    //                     {
                    //                         Name = x.EquipmentParameter.Equipment.Room.Floor.Building.Site.Name
                    //                     }
                    //                 }
                    //             }
                    //         }
                    //     }
                    // }
                })
                .ToListAsync();
            return Ok(result);
        }
    }
}