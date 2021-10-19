using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/racks")]
    public class RackController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public ICommandResult Create(
            [FromBody] CreateRackCommand command,
            [FromServices] CreateRackHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Rack> GetAll(
            [FromServices] IRackRepository repository
        )
        {
            return repository.List();
        }

        [Route("equipments")]
        [HttpGet]
        public IEnumerable<RackEquipment> Equipments(
            [FromServices] ActiveContext context
        )
        {
            return context.RackEquipments
                .AsNoTracking()
                .Include(x => x.BaseEquipment)
                // .Include(x => x.Rack)
                .ToList();
        }
    }
}