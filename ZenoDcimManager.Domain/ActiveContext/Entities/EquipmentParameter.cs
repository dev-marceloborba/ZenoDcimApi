using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared;
using ZenoDcimManager.Shared.Extensions;
using ZenoDcimManager.Shared.Interfaces;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class EquipmentParameter : Entity,
        IPrototype<EquipmentParameter>,
        IDuplicate<EquipmentParameter>
    {
        public EquipmentParameter()
        {

        }

        public string Name { get; set; }
        public string Unit { get; set; }
        public int Scale { get; set; }
        public string DataSource { get; set; }
        public string Expression { get; set; }
        public string Pathname { get; set; }
        public RealtimeData Data { get; set; }
        public List<AlarmRule> AlarmRules { get; set; } = new();

        // Navigations Property
        public Guid? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public string ModbusTagName { get; set; }


        public override string ToString()
        {
            return Name;
        }
        public string GetPathname()
        {
            var pathname = Equipment.Room.Floor.Building.Site.Name
                + Equipment.Room.Floor.Building.Name
                + Equipment.Room.Floor.Name
                + Equipment.Room.Name
                + Equipment.ToString()
                + Name;
            pathname = pathname.Replace(" ", "");
            return pathname.RemoveAccents();
        }

        public EquipmentParameter Clone()
        {
            var clone = (EquipmentParameter)MemberwiseClone();
            clone.SetId(Guid.NewGuid());
            return clone;
        }

        public EquipmentParameter Duplicate()
        {
            var duplicated = Clone();
            duplicated.Name = duplicated.Name + " - cópia";
            return duplicated;
        }
    }
}