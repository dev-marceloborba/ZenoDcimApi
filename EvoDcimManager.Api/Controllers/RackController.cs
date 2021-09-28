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
            [FromServices] CreateRackHandler handler,
            [FromBody] CreateRackCommand command
        )
        {
            var result = (CommandResult)handler.Handle(command);
            return result;
        }

        [Route("")]
        [HttpGet]
        public IReadOnlyCollection<Rack> GetAll(
            [FromServices] IRackRepository repository
        )
        {
            var racks = repository.List();
            return racks;
        }

        [Route("configure")]
        [HttpPost]
        public ActionResult Configure(
            [FromServices] IRackRepository repository
        )
        {
            var rack1 = new Rack(20, "ABC");
            var rack2 = new Rack(20, "CDA");

            repository.Save(rack1);
            repository.Save(rack2);

            return Ok();
        }
    }
}