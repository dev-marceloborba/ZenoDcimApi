using System;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class RackSlot : ValueObject
    {
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public ERackMountType RackMountType { get; set; }
        public string Description { get; set; } = "Disponível";
        public Guid EquipmentId { get; set; }
    }
}