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
    [Route("/v1/storages")]
    public class StorageController : ControllerBase
    {

        [Route("")]
        [HttpPost]
        public ICommandResult Create(
            [FromBody] CreateStorageCommand command,
            [FromServices] CreateStorageHandler handler
        )
        {
            var result = handler.Handle(command);
            return (ICommandResult)result;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Storage> List(
            [FromServices] IStorageRepository _repository
        )
        {
            return _repository.List();
        }
    }
}