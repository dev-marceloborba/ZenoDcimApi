using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.UserContext.Commands.Input;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Infra.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/contracts")]
    public class ContractController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateContract(
          [FromBody] CreateContractCommand command,
          [FromServices] CompanyHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Contract> ListContracts(
          [FromServices] CompanyRepository repository
        )
        {
            return repository.ListContracts();
        }
    }
}