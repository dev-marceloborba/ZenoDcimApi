using System;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
	public class RealtimeData
	{
        public Guid Id { get; set; }
        public int Value { get; set; }
        public DateTime TimeStamp { get; set; }

        public RealtimeData()
		{
			TimeStamp = DateTime.UtcNow;
		}
	}
}

