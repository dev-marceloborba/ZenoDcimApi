using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.Commands;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center/virtual-parameters")]
    [AllowAnonymous]
    public class VirtualParameterController : ControllerBase
    {
        private readonly IVirtualParameterRepository _repository;

        public VirtualParameterController(IVirtualParameterRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateVirtualParameter(
            [FromBody] CreateVirtualParameterCommand command,
            [FromServices] VirtualParameterHandler handler)
        {
            var result = await handler.Handle(command);
            return Ok(result);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateVirtualParameter(
            [FromRoute] Guid id,
            [FromBody] CreateVirtualParameterCommand command)
        {
            var virtualParameter = await _repository.FindByIdAsync(id);
            virtualParameter.Name = command.Name;
            virtualParameter.Unit = command.Unit;
            virtualParameter.Scale = command.Scale;
            virtualParameter.LowLimit = command.LowLimit;
            virtualParameter.LowLowLimit = command.LowLowLimit;
            virtualParameter.HighLimit = command.HighLimit;
            virtualParameter.HighHighLimit = command.HighHighLimit;
            virtualParameter.Expression = command.Expression;

            _repository.Update(virtualParameter);
            await _repository.Commit();

            return Ok(new CommandResult(true, "Parametro virtual atualizado com sucesso", virtualParameter));
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> FindAllVirtualParameters()
        {
            return Ok(await _repository.FindAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> FindVirtualParameterById(
            [FromRoute] Guid id)
        {
            return Ok(await _repository.FindByIdAsync(id));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteVirtualParameter(
            [FromRoute] Guid id)
        {
            var virtualParameter = new VirtualParameter();
            virtualParameter.SetId(id);
            _repository.Delete(virtualParameter);
            await _repository.Commit();

            return Ok(new CommandResult(true, "Parametro virtual excluido com sucesso", virtualParameter));
        }
    }
}

