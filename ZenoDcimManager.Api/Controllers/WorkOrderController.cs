using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Domain.ServiceOrderContext.Handlers;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/work-orders")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderRepository _repository;

        public WorkOrderController(IWorkOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] WorkOrderEditorCommand command,
            [FromServices] WorkOrderHandler handler)
        {
            var result = await handler.Handle(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] WorkOrderEditorCommand command,
            [FromServices] WorkOrderHandler handler)
        {
            command.Id = id;
            var result = await handler.Handle(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> FindAllAsync()
        {
            var result = await _repository.FindAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> FindByIdAsync(
            [FromRoute] Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] Guid id)
        {
            var workOrder = new WorkOrder();
            workOrder.SetId(id);

            _repository.Delete(workOrder);
            await _repository.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("approve/{id}")]
        public async Task<ActionResult> Approve(
            [FromRoute] Guid id)
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.WorkOrderStatus = EWorkOrderStatus.APPROVED;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await _repository.Commit();
            return Ok(workOrder);
        }

        [HttpPost]
        [Route("accept/{id}")]
        public async Task<ActionResult> Accept(
            [FromRoute] Guid id
        )
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.WorkOrderStatus = EWorkOrderStatus.IN_EXECUTION;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await _repository.Commit();
            return Ok(workOrder);
        }
    }
}

