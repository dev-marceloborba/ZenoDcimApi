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
    [Route("v1/modbusTags")]
    public class ModbusTagController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        IEnumerable<ModbusTag> FindAll(
            [FromServices] IModbusTagRepository repository
        )
        {
            return repository.FindAll();
        }

        [Route("")]
        [HttpPost]
        ICommandResult Create(
            [FromBody] ModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            var result = handler.Handle(command);
            return (ICommandResult)result;
        }
    }
}