using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.DataCenterContext.Commands.Inputs;
using ZenoDcimManager.Domain.DataCenterContext.Handlers;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/datacenter")]
    public class DataCenterController : ControllerBase
    {
        [Route("building")]
        [HttpPost]
        [AllowAnonymous]
        public ICommand CreateBuilding(
            [FromBody] CreateBuildingCommand command,
            [FromServices] BuildingHandler handler
        )
        {
            return (ICommand)handler.Handle(command);
        }
    }
}