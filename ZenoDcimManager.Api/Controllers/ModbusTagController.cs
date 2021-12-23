using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ZenoDcimManager.Api.Controllers
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

        [Route("multiple")]
        [HttpPost]
        public ICommandResult CraeteMultipleModbusTags(
            [FromBody] CreateMultipleModbusTagCommand command,
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

        [Route("delete-by-clp/{id}")]
        [HttpDelete]
        public ActionResult DeleteAllByClp(string id, [FromServices] IPlcRepository plcRepository, [FromServices] IModbusTagRepository modbusTagRepository)
        {
            try
            {
                Guid gid = Guid.Parse(id);
                var clp = plcRepository.FindById(gid);
                modbusTagRepository.DeleteAllByClp(clp);
                return Ok();
            } catch
            {
                return BadRequest();
            }
            
        }
    }
}