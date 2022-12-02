using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/work-orders")]
    public class WorkOrderController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] CreateWorkOrderCommand command,
            [FromServices] IWorkOrderRepository repository)
        {
            command.Validate();

            if (command.Valid)
            {
                Console.WriteLine("valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            var workOrder = new WorkOrder
            {
                SiteId = command.SiteId,
                BuildingId = command.BuildingId,
                FloorId = command.FloorId,
                RoomId = command.RoomId,
                EquipmentId = command.EquipmentId,
                Description = command.Description,
                FinalDate = command.FinalDate,
                InitialDate = command.InitialDate,
                MaintenanceType = command.MaintenanceType,
                Nature = command.Nature,
                OrderType = command.OrderType,
                Responsible = command.Responsible,
                ResponsibleType = command.ResponsibleType,
                WorkOrderStatus = EWorkOrderStatus.CREATED,
                Title = command.Title,
                Priority = command.Priority,
                EstimatedRepairTime = command.EstimatedRepairTime,
                RealRepairTime = command.RealRepairTime,
                Cost = command.Cost
            };

            await repository.CreateAsync(workOrder);
            await repository.Commit();

            return Ok(new CommandResult(true, "Ordem de serviço criada com sucesso", workOrder));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] CreateWorkOrderCommand command,
            [FromServices] IWorkOrderRepository repository)
        {
            var workOrder = await repository.FindByIdAsync(id);
            workOrder.Description = command.Description;
            workOrder.FinalDate = command.FinalDate;
            workOrder.InitialDate = command.InitialDate;
            workOrder.MaintenanceType = command.MaintenanceType;
            workOrder.Nature = command.Nature;
            workOrder.OrderType = command.OrderType;
            workOrder.Responsible = command.Responsible;
            workOrder.ResponsibleType = command.ResponsibleType;
            workOrder.Title = command.Title;
            workOrder.Priority = command.Priority;
            workOrder.EstimatedRepairTime = command.EstimatedRepairTime;
            workOrder.RealRepairTime = command.RealRepairTime;
            workOrder.Cost = command.Cost;
            workOrder.TrackModifiedDate();

            repository.Update(workOrder);
            await repository.Commit();

            return Ok(new CommandResult(true, "Ordem de serviço atualizada com sucesso", workOrder));
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> FindAllAsync(
            [FromServices] IWorkOrderRepository repository)
        {
            var result = await repository.FindAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> FindByIdAsync(
            [FromRoute] Guid id,
            [FromServices] IWorkOrderRepository repository)
        {
            var result = await repository.FindByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] IWorkOrderRepository repository)
        {
            var workOrder = new WorkOrder();
            workOrder.SetId(id);

            repository.Delete(workOrder);
            await repository.Commit();

            return Ok();
        }
    }
}

