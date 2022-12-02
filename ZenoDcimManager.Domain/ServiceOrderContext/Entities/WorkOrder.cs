using System;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Entities
{
    public class WorkOrder : Entity
    {
        public Site Site { get; set; }
        public Building Building { get; set; }

        public Floor Floor { get; set; }
        public Room Room { get; set; }
        public Equipment Equipment { get; set; }
        public EWorkOrderNature Nature { get; set; }
        public EResponsibleType ResponsibleType { get; set; }
        public string Responsible { get; set; }
        public EMaintenanceType MaintenanceType { get; set; }
        public EWorkOrderType OrderType { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Description { get; set; }
        public EWorkOrderStatus WorkOrderStatus { get; set; }
        public int EstimatedRepairTime { get; set; }
        public int? RealRepairTime { get; set; }
        public decimal? Cost { get; set; }
        public string Title { get; set; }
        public EWorkOrderPriority Priority { get; set; }

        // Navigation properties
        public Guid RoomId { get; set; }
        public Guid SiteId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid EquipmentId { get; set; }

        public WorkOrder()
        {
        }

    }
}

