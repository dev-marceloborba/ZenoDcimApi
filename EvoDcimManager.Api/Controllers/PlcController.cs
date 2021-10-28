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
        public IEnumerable<Plc> GetAllPlcs(
            [FromServices] IPlcRepository repository
        )
        {
            return repository.FindAll();
        }

        [Route("{id}")]
        [HttpGet]
        public Plc GetPlcById(
            string id,
            [FromServices] IPlcRepository repository
        )
        {
            var Id = Guid.Parse(id);
            return repository.FindById(Id);
        }

        [Route("")]
        [HttpPost]
        public ICommandResult CreatePlc(
            [FromBody] CreatePlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public ICommandResult EditPlc(
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
        public ICommandResult DeletePlc(
            [FromBody] DeletePlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }
    }
}