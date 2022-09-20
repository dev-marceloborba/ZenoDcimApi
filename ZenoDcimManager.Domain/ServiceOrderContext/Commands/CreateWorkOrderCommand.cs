using System;
using Flunt.Notifications;
using Flunt.Validations;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Commands
{
	public class CreateWorkOrderCommand : Notifiable, ICommand
    {
        public Guid SiteId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid RoomId { get; set; }
        public Guid EquipmentId { get; set; }
        public EWorkOrderNature Nature { get; set; }
        public EResponsibleType ResponsibleType { get; set; }
        public string Responsible { get; set; }
        public EMaintenanceType MaintenanceType { get; set; }
        public EWorkOrderType OrderType { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                   .Requires()
                   .IsGreaterThan(InitialDate, FinalDate, "InitialDate", "Data final deve ser maior que a data inicial")
            );
        }
    }
}

