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
    [Route("/v1/servers")]
    public class ServerController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public CommandResult Create(
            [FromBody] CreateServerCommand command,
            [FromServices] CreateServerHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Server> GetAll(
            [FromServices] IServerRepository repository
        )
        {
            return repository.List();
        }
    }
}