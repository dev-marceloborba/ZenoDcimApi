using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Handlers;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/modbusTags")]
    public class ModbusTagController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<ModbusTag> GetAllModbusTags(
            [FromServices] IModbusTagRepository repository
        )
        {
            return repository.FindAll();
        }

        [Route("")]
        [HttpPost]
        public ICommandResult CreateModbusTag(
            [FromBody] CreateModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public ICommandResult EditModbusTag(
            [FromBody] EditModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteModbusTag(
            string id,
            [FromServices] IModbusTagRepository repository
        )
        {
            try
            {
                Guid gid = Guid.Parse(id);
                var modbusTag = repository.FindById(gid);
                repository.Delete(modbusTag);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}