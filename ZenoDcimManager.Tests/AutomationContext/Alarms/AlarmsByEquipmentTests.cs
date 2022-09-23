using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.AutomationContext.Alarms
{

    public class CAlarm
    {
        public Guid Id { get; set; }
        public string Pathname { get; set; }
    }

    public class AlarmsEquipment
    {
        public Guid Id { get; set; }
        public string Site { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Equipment { get; set; }
        public string Parameter { get; set; }
    }

    [TestClass]
    public class AlarmsByEquipmentTests
    {

        [TestMethod]
        [TestCategory("alarms-by-equipment")]
        public void ShouldSplitDataIntoGroups()
        {
            var pathnames = new List<CAlarm>();
            var alarms = new List<AlarmsEquipment>();
            pathnames.Add(new CAlarm
            {
                Id = Guid.NewGuid(),
                Pathname = "Canoas_1*Data_Hall_1*Andar_1*Transformador_A*Disjuntor_2*Corrente"
            });
            pathnames.Add(new CAlarm
            {
                Id = Guid.NewGuid(),
                Pathname = "Canoas_1*Data_Hall_1*Andar_1*Transformador_A*Disjuntor_1*Tensão"
            });
            pathnames.Add(new CAlarm
            {
                Id = Guid.NewGuid(),
                Pathname = "Canoas_1*Data_Hall_1*Andar_1*Transformador_A*Disjuntor_1*Tensão"
            });

            foreach (var item in pathnames)
            {
                var arr = item.Pathname.Split("*");
                alarms.Add(new AlarmsEquipment
                {
                    Id = item.Id,
                    Site = arr[0],
                    Building = arr[1],
                    Floor = arr[2],
                    Room = arr[3],
                    Equipment = arr[4],
                    Parameter = arr[5]
                });
            }

            var q = from p in alarms
                    group p by p.Equipment into g
                    select new
                    {
                        g.Key,
                        Total = g.Count()
                    };

            foreach (var item in q)
            {
                Console.WriteLine(item.Total);
            }

            // Console.WriteLine(q);

            Assert.Fail();
        }
    }
}