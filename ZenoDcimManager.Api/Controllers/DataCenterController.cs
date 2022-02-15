using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/data-center")]
    public class DataCenterController : ControllerBase
    {
        [Route("building")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateBuilding(
            [FromBody] CreateBuildingCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("building")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Building> FindAllBuildings(
            [FromServices] IDataCenterRepository repository
        )
        {
            return repository.FindAllBuildings();
        }


        [Route("building/{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteBuilding(
            Guid id,
            [FromServices] IDataCenterRepository repository
        )
        {
            try
            {
                repository.DeleteBuilding(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}