using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Domain.ServiceOrderContext.DTOs;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Domain.ServiceOrderContext.Handlers;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;

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
            // return Ok(command);
            var result = await handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);

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
        public async Task<ActionResult> FindAllAsync(
            [FromQuery] WorkOrderFilterDto filterDto
        )
        {
            var result = await _repository.FindFilteredWorkOrders(filterDto);
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
        [Route("send-to-approval/{id}")]
        public async Task<ActionResult> SendToApproval(
            [FromRoute] Guid id,
            [FromQuery] string user,
            [FromServices] IWorkOrderEventRepository workOrderEventRepository
        )
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.Status = EWorkOrderStatus.IN_APPROVAL;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await workOrderEventRepository.CreateAsync(new WorkOrderEvent
            {
                WorkOrderId = workOrder.Id,
                User = user,
                Status = EWorkOrderStatus.IN_APPROVAL
            });
            await _repository.Commit();
            await workOrderEventRepository.Commit();
            return Ok(workOrder);
        }

        [HttpPost]
        [Route("approve/{id}")]
        public async Task<ActionResult> Approve(
            [FromRoute] Guid id,
            [FromQuery] string user,
            [FromServices] IWorkOrderEventRepository workOrderEventRepository)
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.Status = EWorkOrderStatus.APPROVED;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await workOrderEventRepository.CreateAsync(new WorkOrderEvent
            {
                WorkOrderId = workOrder.Id,
                User = user,
                Status = EWorkOrderStatus.APPROVED
            });
            await _repository.Commit();
            await workOrderEventRepository.Commit();
            return Ok(workOrder);
        }

        [HttpPost]
        [Route("accept/{id}")]
        public async Task<ActionResult> Accept(
            [FromRoute] Guid id,
            [FromQuery] string user,
            [FromServices] IWorkOrderEventRepository workOrderEventRepository
        )
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.Status = EWorkOrderStatus.IN_EXECUTION;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await workOrderEventRepository.CreateAsync(new WorkOrderEvent
            {
                WorkOrderId = workOrder.Id,
                User = user,
                Status = EWorkOrderStatus.IN_EXECUTION
            });
            await _repository.Commit();
            await workOrderEventRepository.Commit();
            return Ok(workOrder);
        }

        [HttpPost]
        [Route("reject/{id}")]
        public async Task<ActionResult> Reject(
            [FromRoute] Guid id,
            [FromQuery] string user,
            [FromServices] IWorkOrderEventRepository workOrderEventRepository
        )
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.Status = EWorkOrderStatus.REJECTED;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await workOrderEventRepository.CreateAsync(new WorkOrderEvent
            {
                WorkOrderId = workOrder.Id,
                User = user,
                Status = EWorkOrderStatus.REJECTED
            });
            await _repository.Commit();
            await workOrderEventRepository.Commit();
            return Ok(workOrder);
        }

        [HttpPost]
        [Route("cancel/{id}")]
        public async Task<ActionResult> Cancel(
            [FromRoute] Guid id,
            [FromQuery] string user,
            [FromServices] IWorkOrderEventRepository workOrderEventRepository
        )
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.Status = EWorkOrderStatus.CANCELED;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await workOrderEventRepository.CreateAsync(new WorkOrderEvent
            {
                WorkOrderId = workOrder.Id,
                User = user,
                Status = EWorkOrderStatus.CANCELED
            });
            await _repository.Commit();
            await workOrderEventRepository.Commit();
            return Ok(workOrder);
        }

        [HttpPost]
        [Route("finish/{id}")]
        public async Task<ActionResult> Finish(
            [FromRoute] Guid id,
            [FromQuery] string user,
            [FromServices] IWorkOrderEventRepository workOrderEventRepository
        )
        {
            var workOrder = await _repository.FindByIdAsync(id);
            workOrder.Status = EWorkOrderStatus.FINISHED;
            workOrder.TrackModifiedDate();
            _repository.Update(workOrder);
            await workOrderEventRepository.CreateAsync(new WorkOrderEvent
            {
                WorkOrderId = workOrder.Id,
                User = user,
                Status = EWorkOrderStatus.FINISHED
            });
            await _repository.Commit();
            await workOrderEventRepository.Commit();
            return Ok(workOrder);
        }
    }
}

