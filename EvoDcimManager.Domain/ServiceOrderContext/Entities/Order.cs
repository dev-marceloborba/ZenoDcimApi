using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.ServiceOrderContext.Enums;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ServiceOrderContext.Entities
{
    public class Order : Entity
    {
        public Order(string company, EOrderStatus status, EOrderType type, DateTime createdDate)
        {
            Company = company;
            Status = status;
            Type = type;
            CreatedDate = createdDate;
            Timelines = new List<Timeline>();
            Activities = new List<Activity>();
        }

        public string Company { get; private set; }
        public EOrderStatus Status { get; private set; }
        public EOrderType Type { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime OpenedDate { get; private set; }
        public DateTime FinishedDate { get; private set; }
        public DateTime RejectedDate { get; private set; }
        public DateTime CancelledDate { get; private set; }
        public IList<Timeline> Timelines { get; private set; }
        public IList<Activity> Activities { get; private set; }

        public void AnalyseOrder()
        {
            Status = EOrderStatus.IN_ANALYSIS;
        }
        public void OpenOrder()
        {
            Status = EOrderStatus.OPENED;
            OpenedDate = DateTime.UtcNow;
        }
        public void StartWorkOnOrder()
        {
            Status = EOrderStatus.IN_WORK;
        }
        public void FinishOrder()
        {
            Status = EOrderStatus.FINISHED;
            FinishedDate = DateTime.UtcNow;
        }

        public void RejectOrder()
        {
            Status = EOrderStatus.REJECTED;
            RejectedDate = DateTime.UtcNow;
        }

        public void CancelOrder()
        {
            Status = EOrderStatus.CANCELLED;
            CancelledDate = DateTime.UtcNow;
        }

        public void AddTimeline(Timeline timeline)
        {
            Timelines.Add(timeline);
        }
    }
}