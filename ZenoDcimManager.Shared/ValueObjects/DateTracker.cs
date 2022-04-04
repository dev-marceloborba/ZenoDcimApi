using System;
namespace ZenoDcimManager.Shared.ValueObjects
{
	public abstract class DateTracker
	{
        public DateTime CreatedDate { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public DateTracker()
		{
			CreatedDate = DateTime.UtcNow;
		}

		public void TrackModifiedDate()
        {
			ModifiedDate = DateTime.UtcNow;
        }
	}
}

