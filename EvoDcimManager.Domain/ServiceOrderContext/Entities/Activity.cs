using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ServiceOrderContext.Entities
{
    public class Activity : Entity
    {
        public Activity(string description)
        {
            Description = description;
            Done = false;
        }

        public string Description { get; private set; }
        public bool Done { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUndone()
        {
            Done = false;
        }
    }
}