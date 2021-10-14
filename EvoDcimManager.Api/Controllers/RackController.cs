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
    }
}