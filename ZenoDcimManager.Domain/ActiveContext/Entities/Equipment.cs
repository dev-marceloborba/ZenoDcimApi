using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Equipment : Entity
    {
        public int Class { get; private set; }
        public string Component { get; private set; }
        public string ComponentCode { get; private set; }
        public string Description { get; private set; }
        public Rack Rack { get; private set; }
        public RackPdu RackPdu { get; private set; }
        public List<EquipmentParameter> EquipmentParameters { get; private set; } = new List<EquipmentParameter>();
        public EEquipmentGroup Group { get; private set; }
        public EEquipmentStatus Status { get; private set; }
        public int Alarms { get; private set; }
        public Guid? RackId { get; private set; }
        public Guid? RackPduId { get; private set; }
        public Guid? RoomId { get; private set; }

        public Equipment()
        {

        }

        public Equipment(int @class, string component, string componentCode, string description, Rack rack, RackPdu rackPdu, EEquipmentGroup group, EEquipmentStatus status, int alarms)
        {
            Class = @class;
            Component = component;
            ComponentCode = componentCode;
            Description = description;
            Rack = rack;
            RackPdu = rackPdu;
            Group = group;
            Status = status;
            Alarms = alarms;
        }

        public void AddEquipmentParameter(EquipmentParameter parameter)
        {
            EquipmentParameters.Add(parameter);
        }

        public void ClearList()
        {
            EquipmentParameters.Clear();
        }
    }
}