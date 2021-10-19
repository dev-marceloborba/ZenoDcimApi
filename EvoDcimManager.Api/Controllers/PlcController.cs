using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Handlers;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/plcs")]
    public class PlcController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        IEnumerable<Plc> FindAll(
            [FromServices] IPlcRepository repository
        )
        {
            return repository.FindAll();
        }

        [Route("")]
        [HttpPost]
        ICommandResult Create(
            [FromBody] PlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            var result = handler.Handle(command);
            return (ICommandResult)result;
        }
    }
}