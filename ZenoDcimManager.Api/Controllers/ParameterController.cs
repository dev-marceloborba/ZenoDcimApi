using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center")]
    [AllowAnonymous]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterRepository _repository;

        public ParameterController(IParameterRepository repository)
        {
            _repository = repository;
        }

        [Route("parameters")]
        [HttpPost]
        public async Task<ICommandResult> CreateParameter(
            [FromBody] CreateParameterCommand command,
            [FromServices] ParameterHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("parameters/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateParameter(
          [FromRoute] Guid id,
          [FromBody] CreateParameterCommand command,
          [FromServices] ParameterHandler handler)
        {
            try
            {
                var parameter = await _repository.FindByIdAsync(id);
                parameter.HighLimit = command.HighLimit;
                parameter.LowLimit = command.LowLimit;
                parameter.Name = command.Name;
                parameter.Scale = command.Scale;
                parameter.Unit = command.Unit;
                parameter.TrackModifiedDate();
                _repository.Update(parameter);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Parâmetro editado com sucesso", parameter));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Não foi possivel editar o parâmetro", new { id }));
            }
        }

        [Route("parameters")]
        [HttpGet]
        public async Task<IEnumerable<Parameter>> FindAllParameters()
        {
            return await _repository.FindAllAsync();
        }

        [Route("parameters/{Id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteParameter(Guid id)
        {
            try
            {
                var parameter = await _repository.FindByIdAsync(id);
                _repository.Delete(parameter);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("parametersByGroup/{group}")]
        [HttpGet]
        public async Task<IEnumerable<Parameter>> FindParametersByGroupd(string group)
        {
            return await _repository.FindParametersByGroup(group);
        }

        [Route("parameters/groupAssociation")]
        [HttpPost]
        public async Task<ICommandResult> CreateEquipmentOnGroup(
            [FromServices] ParameterGroupHandler handler,
            [FromBody] CreateEquipmentOnGroupCommand command
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }
    }
}