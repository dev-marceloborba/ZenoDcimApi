using System;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Entities
{
    public class WorkOrderEvent : Entity
    {
        public string User { get; set; }
        public EWorkOrderStatus Status { get; set; }
        public WorkOrder WorkOrder { get; set; }
        // navigation properties
        public Guid WorkOrderId { get; set; }
        public WorkOrderEvent()
        {

        }
    }
}