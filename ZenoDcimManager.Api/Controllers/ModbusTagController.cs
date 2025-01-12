﻿using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/modbusTags")]
    public class ModbusTagController : ControllerBase
    {
        private readonly IModbusTagRepository _repository;

        public ModbusTagController(IModbusTagRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ModbusTag> GetAllModbusTags()
        {
            return _repository.FindAll();
        }

        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreateModbusTag(
            [FromBody] CreateModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("multiple")]
        [HttpPost]
        public async Task<ICommandResult> CreateMultipleModbusTags(
            [FromBody] CreateMultipleModbusTagCommand command,
            [FromServices] ModbusTagHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
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
        public async Task<ActionResult> DeleteModbusTag(Guid id)
        {
            var modbusTag = new ModbusTag();
            try
            {
                modbusTag.SetId(id);
                _repository.Delete(modbusTag);
                await _repository.Commit();
                return Ok(modbusTag);
            }
            catch
            {
                return BadRequest(modbusTag);
            }
        }

        [Route("delete-by-clp/{id}")]
        [HttpDelete]
        public ActionResult DeleteAllByClp(
            Guid id,
            [FromServices] IPlcRepository plcRepository,
            [FromServices] IModbusTagRepository modbusTagRepository)
        {
            try
            {
                var plc = new Plc();
                plc.SetId(id);
                modbusTagRepository.DeleteAllByClp(plc);
                modbusTagRepository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}