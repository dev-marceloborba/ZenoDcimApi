using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/plcs")]
    public class PlcController : ControllerBase
    {
        private readonly IPlcRepository _repository;

        public PlcController(IPlcRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Plc> GetAllPlcs()
        {
            return _repository.FindAll();
        }

        [Route("{id}")]
        [HttpGet]
        public Plc GetPlcById(string id)
        {
            var Id = Guid.Parse(id);
            return _repository.FindById(Id);
        }

        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreatePlc(
            [FromBody] CreatePlcCommand command,
            [FromServices] PlcHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
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