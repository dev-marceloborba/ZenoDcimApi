﻿using System;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class ModbusTag : Entity
    {
        public string Name { get; set; }
        public double Deadband { get; set; }
        public int Address { get; set; }
        public int DataSize { get; set; }
        public string DataType { get; set; }
        public int Scan { get; set; }
        // Navigation property
        public Guid? PlcId { get; set; }
        public string? EquipmentParameterName { get; set; }
    }
}