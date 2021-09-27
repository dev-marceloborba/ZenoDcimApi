using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class RackSlot : ValueObject
    {
        public int Position { get; private set; }
        public int Occupation { get; private set; }

        public RackSlot(int position, int occupation)
        {
            Position = position;
            Occupation = occupation;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Position, 0, "Position", "Position should be greater than zero")
                .IsGreaterThan(Occupation, 0, "Occupation", "Occupation should be greater than zero")
            );
        }
    }
}