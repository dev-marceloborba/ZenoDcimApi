using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using System;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Handlers
{
    public class WorkOrderHandler : Notifiable, ICommandHandler<WorkOrderEditorCommand>
    {
        private readonly IWorkOrderRepository _workOrderRepository;
        private readonly IWorkOrderEventRepository _workOrderEventRepository;

        public WorkOrderHandler(IWorkOrderRepository workOrderRepository, IWorkOrderEventRepository workOrderEventRepository)
        {
            _workOrderRepository = workOrderRepository;
            _workOrderEventRepository = workOrderEventRepository;
        }

        public async Task<ICommandResult> Handle(WorkOrderEditorCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new CommandResult(false, "Erro ao criar/alterar ordem", command.Notifications);

            if (command.Id?.GetType() == typeof(Guid))
            {
                var workOrder = await _workOrderRepository.FindByIdAsync((Guid)command.Id);
                MapObject(workOrder, command);
                workOrder.Status = command.Status;
                workOrder.TrackModifiedDate();

                _workOrderRepository.Update(workOrder);
                await _workOrderRepository.Commit();

                return new CommandResult(true, "Ordem de serviço alterada com sucesso", workOrder);
            }
            else
            {
                var workOrder = new WorkOrder();
                MapObject(workOrder, command);
                workOrder.Status = EWorkOrderStatus.DRAFT;

                await _workOrderRepository.CreateAsync(workOrder);
                await _workOrderEventRepository.CreateAsync(new WorkOrderEvent
                {
                    WorkOrderId = workOrder.Id,
                    User = command.User,
                    Status = EWorkOrderStatus.DRAFT
                });
                await _workOrderRepository.Commit();
                await _workOrderEventRepository.Commit();

                return new CommandResult(true, "Ordem de serviço criada com sucesso", workOrder);
            }
        }

        private void MapObject(WorkOrder workOrder, WorkOrderEditorCommand command)
        {
            workOrder.SiteId = command.SiteId;
            workOrder.BuildingId = command.BuildingId;
            workOrder.FloorId = command.FloorId;
            workOrder.RoomId = command.RoomId;
            workOrder.EquipmentId = command.EquipmentId;
            workOrder.Description = command.Description;
            workOrder.FinalDate = command.FinalDate;
            workOrder.InitialDate = command.InitialDate;
            workOrder.MaintenanceType = command.MaintenanceType;
            workOrder.Nature = command.Nature;
            workOrder.OrderType = command.OrderType;
            workOrder.Supervisor = command.User;
            workOrder.ResponsibleType = command.ResponsibleType;
            workOrder.Title = command.Title;
            workOrder.Priority = command.Priority;
            workOrder.EstimatedRepairTime = command.EstimatedRepairTime;
            workOrder.RealRepairTime = command.RealRepairTime;
            workOrder.Cost = command.Cost;
        }
    }
}