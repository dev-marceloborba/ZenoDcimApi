using System;
using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class RackSlot : ValueObject
    {
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public string Description { get; set; } = "Disponível";
        public Guid EquipmentId { get; set; }
    }
}