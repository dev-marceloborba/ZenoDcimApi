using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Tests.AutomationContext.VirtualParameters
{
    [TestClass]
    public class VirtualParametersTests
    {
        [TestMethod]
        [TestCategory("VirtualParameters")]
        public void ShouldComputeVirtualParameters()
        {

            var equipmentId = Guid.NewGuid();

            var equipment = new Equipment
            {
                Component = "Equip1"
            };
            equipment.SetId(equipmentId);

            var parameter1 = new EquipmentParameter
            {
                Name = "Tensao"
            };
            parameter1.SetId(Guid.NewGuid());

            var parameter2 = new EquipmentParameter
            {
                Name = "Corrente"
            };
            parameter2.SetId(Guid.NewGuid());

            equipment.EquipmentParameters.Add(parameter1);
            equipment.EquipmentParameters.Add(parameter2);

            var virtualParameter = new VirtualParameter
            {
                Name = "Potência",
                Expression = "Equip1.Tensao * Equip1.Corrente"
            };

            var parameter1RealtimeData = new RealtimeData
            {
                Id = Guid.NewGuid(),
                Value = 220
            };

            var parameter2RealtimeData = new RealtimeData
            {
                Id = Guid.NewGuid(),
                Value = 10
            };

            parameter1.Equipment = equipment;
            parameter2.Equipment = equipment;

            parameter1.Data = parameter1RealtimeData;
            parameter2.Data = parameter2RealtimeData;

            var variables = virtualParameter.Expression.Split(' ');
            for (int i = 0; i < variables.Length; i++)
            {
                if (variables[i].Length > 1)
                    Console.WriteLine(variables[i]);

            }



            Assert.Fail();
        }
    }
}