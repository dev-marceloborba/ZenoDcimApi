namespace ZenoDcimManager.Domain.ServiceOrderContext.Enums
{
    public enum EWorkOrderStatus
    {
        DRAFT = 0,
        IN_APPROVAL = 1,
        APPROVED = 2,
        WAITING_EXECUTION = 3,
        IN_EXECUTION = 4,
        FINISHED = 5,
        CANCELED = 6,
        REJECTED = 7
    }
}