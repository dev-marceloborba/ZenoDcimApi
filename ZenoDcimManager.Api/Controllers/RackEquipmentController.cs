using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Commands;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/rack-equipments")]
    [AllowAnonymous]
    public class RackEquipmentController : ControllerBase
    {
        private readonly IRackEquipmentRepository _repository;

        public RackEquipmentController(IRackEquipmentRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreateRackEquipment(
            [FromBody] CreateRackEquipmentCommand command,
            [FromServices] RackEquipmentHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<RackEquipment>> GetAllRackEquipments()
        {
            return await _repository.FindAll();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> FindRackEquipmentById(
            [FromRoute] Guid id)
        {
            var result = await _repository.FindById(id);
            return Ok(result);
        }

        [Route("rack/{id}")]
        [HttpGet]
        public async Task<ActionResult> FindEquipmentsByRack(
            [FromRoute] Guid id)
        {
            var result = await _repository.FindRackEquipmentsByRackId(id);
            return Ok(result);
        }

        [Route("without-rack")]
        [HttpGet]
        public async Task<ActionResult> FindEquipmentsWithoutRack(
        )
        {
            var result = await _repository.FindEquipmentsWithoutRack();
            return Ok(result);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateRackEquipment(
            [FromRoute] Guid id,
            [FromBody] CreateRackEquipmentCommand command)
        {
            var rackEquipment = await _repository.FindById(id);
            rackEquipment.InitialPosition = command.InitialPosition;
            rackEquipment.FinalPosition = command.FinalPosition;
            rackEquipment.RackEquipmentType = command.RackEquipmentType; ;
            rackEquipment.BaseEquipment.Name = command.Name;
            rackEquipment.BaseEquipment.Model = command.Model;
            rackEquipment.BaseEquipment.Manufactor = command.Manufactor;
            rackEquipment.BaseEquipment.SerialNumber = command.SerialNumber;
            rackEquipment.Size = command.Size;
            rackEquipment.RackId = command.RackId;
            rackEquipment.Client = command.Client;
            rackEquipment.Function = command.Function;
            rackEquipment.RackMountType = command.RackMountType;
            rackEquipment.RackEquipmentOrientation = command.RackEquipmentOrientation;
            rackEquipment.Occupation = command.Occupation;
            rackEquipment.Power = command.Power;
            rackEquipment.Weight = command.Weight;
            rackEquipment.Status = command.Status;
            rackEquipment.Description = command.Description;

            rackEquipment.TrackModifiedDate();

            _repository.Update(rackEquipment);
            await _repository.Commit();

            return Ok(new CommandResult(true, "Equipamento de rack alterado com sucesso", rackEquipment));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteRackEquipment(
            [FromRoute] Guid id
        )
        {
            var rackEquipment = new RackEquipment();
            rackEquipment.SetId(id);

            _repository.Delete(rackEquipment);
            await _repository.Commit();

            return Ok();
        }
    }
}