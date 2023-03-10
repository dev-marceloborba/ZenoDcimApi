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
                workOrder.WorkOrderStatus = command.Status;
                workOrder.TrackModifiedDate();

                _workOrderRepository.Update(workOrder);
                await _workOrderRepository.Commit();

                return new CommandResult(true, "Ordem de serviço alterada com sucesso", workOrder);
            }
            else
            {
                var workOrder = new WorkOrder();
                MapObject(workOrder, command);
                workOrder.WorkOrderStatus = EWorkOrderStatus.DRAFT;

                await _workOrderRepository.CreateAsync(workOrder);
                await _workOrderEventRepository.CreateAsync(new WorkOrderEvent
                {
                    User = command.Supervisor,
                    Status = EWorkOrderStatus.DRAFT
                });
                await _workOrderRepository.Commit();
                await _workOrderEventRepository.Commit();

                return new CommandResult(true, "Ordem de serviço criada com sucesso", workOrder);
            }
        }

        private void MapObject(WorkOrder workOrder, WorkOrderEditorCommand command)
        {
            workOrder.Description = command.Description;
            workOrder.FinalDate = command.FinalDate;
            workOrder.InitialDate = command.InitialDate;
            workOrder.MaintenanceType = command.MaintenanceType;
            workOrder.Nature = command.Nature;
            workOrder.OrderType = command.OrderType;
            workOrder.Executor = command.Executor;
            workOrder.Supervisor = command.Supervisor;
            workOrder.Manager = command.Manager;
            workOrder.ResponsibleType = command.ResponsibleType;
            workOrder.Title = command.Title;
            workOrder.Priority = command.Priority;
            workOrder.EstimatedRepairTime = command.EstimatedRepairTime;
            workOrder.RealRepairTime = command.RealRepairTime;
            workOrder.Cost = command.Cost;
        }
    }
}