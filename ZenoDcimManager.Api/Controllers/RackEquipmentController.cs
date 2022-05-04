using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/rack-equipments")]
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
    }
}