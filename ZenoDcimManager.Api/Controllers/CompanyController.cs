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
    [Route("/v1/companies")]
    public class CompanyController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateCompany(
           [FromBody] CreateCompanyCommand command,
           [FromServices] CompanyHandler handler
        )
        {
            return (ICommandResult) await handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Company>> ListCompanies(

            [FromServices] ICompanyRepository repository
        )
        {
            return await repository.ListCompanies();
        }

        [Route("with-contracts")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Company>> ListCompaniesWithContracts(

            [FromServices] ICompanyRepository repository
        )
        {
            return await repository.ListCompaniesWithContract();
        }
    }
}