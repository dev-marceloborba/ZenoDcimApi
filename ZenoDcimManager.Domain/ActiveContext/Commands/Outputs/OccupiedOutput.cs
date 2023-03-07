using System;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Outputs
{
    public class OccupiedOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double PowerCapacity { get; set; }
        public int RackCapacity { get; set; }
        public int OccupiedCapacity { get; set; }
        public double OccupiedPower { get; set; }
        public int RacksQuantity { get; set; }
        public int RoomsQuantity { get; set; }
    }
}