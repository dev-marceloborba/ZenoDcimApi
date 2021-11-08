using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/rack-equipments")]
    public class RackEquipmentController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public CommandResult CreateRackEquipment(
            [FromBody] CreateRackEquipmentCommand command,
            [FromServices] RackEquipmentHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<RackEquipment> GetAllRackEquipments(
            [FromServices] IRackEquipmentRepository repository
        )
        {
            return repository.FindAll();
        }
    }
}