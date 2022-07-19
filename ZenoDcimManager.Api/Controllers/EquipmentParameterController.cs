using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center")]
    [AllowAnonymous]
    public class EquipmentParameterControler : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public EquipmentParameterControler(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("building/floor/room/equipment/parameter")]
        [HttpPost]
        public async Task<ICommandResult> CreateEquipmentParameter(
          [FromBody] CreateEquipmentParameterCommand command,
          [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEquipmentParameter(
            [FromRoute] Guid id,
            [FromBody] CreateEquipmentParameterCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var equipmentParameter = await _repository.FindEquipmentParameterById(id);
                equipmentParameter.DataSource = command.DataSource;
                equipmentParameter.HighLimit = command.HighLimit;
                equipmentParameter.LowLimit = command.LowLimit;
                equipmentParameter.Unit = command.Unit;
                equipmentParameter.Scale = command.Scale;
                equipmentParameter.ModbusTagName = command.Address;
                equipmentParameter.TrackModifiedDate();
                _repository.UpdateEquipmentParameter(equipmentParameter);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Parâmetro de equipamento atualizado com sucesso", equipmentParameter));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar parâmetro de equipamento", new { id }));
            }
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpGet]
        public async Task<EquipmentParameter> FindEquipmentParameterById(Guid id)
        {
            return await _repository.FindEquipmentParameterById(id);
        }

        [Route("building/floor/room/equipment/parameter/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEquipmentParameter(Guid id)
        {
            try
            {
                var parameter = new EquipmentParameter();
                parameter.SetId(id);
                _repository.DeleteEquipmentParameter(parameter);
                await _repository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("building/floor/room/equipment/parameter/multiple")]
        [HttpPost]
        public async Task<ICommandResult> CreateMultipleEquipmentParameter(
            [FromBody] CreateMultipleParametersCommand command,
            [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("building/floor/room/equipmentParameterById/{id}")]
        [HttpGet]
        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id)
        {
            return _repository.FindParametersByEquipmentId(id);
        }

        [Route("building/floor/room/equipment/parameters")]
        [HttpGet]
        public async Task<IEnumerable<EquipmentParameter>> FindAllEquipmentParameters()
        {
            return await _repository.FindAllEquipmentParameters();
        }
    }
}