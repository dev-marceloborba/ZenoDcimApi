using System.Collections.Generic;
using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
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