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
    [Route("/v1/switches")]
    public class SwitchController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public ICommandResult Create(
            [FromBody] CreateSwitchCommand command,
            [FromServices] SwitchHandler handler
        )
        {
            var result = handler.Handle(command);
            return (ICommandResult)result;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Switch> List(
            [FromServices] ISwitchRepository _repository
        )
        {
            return _repository.List();
        }
    }
}