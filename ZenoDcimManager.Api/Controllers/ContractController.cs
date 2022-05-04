using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.UserContext.Commands.Input;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/contracts")]
    public class ContractController : ControllerBase
    {
        private readonly ICompanyRepository _repository;

        public ContractController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateContract(
          [FromBody] CreateContractCommand command,
          [FromServices] CompanyHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Contract>> ListContracts()
        {
            return await _repository.ListContracts();
        }
    }
}