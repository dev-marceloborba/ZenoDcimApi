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
        public IEnumerable<ModbusTag> FindAll(
            [FromServices] IModbusTagRepository repository
        )
        {
            return repository.FindAll();
        }

        [Route("")]
        [HttpPost]
        public ICommandResult Create(
            [FromBody] ModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public ICommandResult Edit(
            [FromBody] EditModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete("{id}")]
        public ActionResult Delete(
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