using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Handlers;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/plcs")]
    public class PlcController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Plc> FindAll(
            [FromServices] IPlcRepository repository
        )
        {
            return repository.FindAll();
        }

        [Route("")]
        [HttpPost]
        public ICommandResult Create(
            [FromBody] PlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut("{id}")]
        public ICommandResult Edit(
            string id,
            [FromBody] EditPlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            command.Id = Guid.Parse(id);
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public ICommandResult Delete(
            [FromBody] DeletePlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }
    }
}