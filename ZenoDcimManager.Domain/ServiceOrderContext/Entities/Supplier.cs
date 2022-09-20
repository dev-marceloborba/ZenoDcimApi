using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Entities
{
    public class Supplier : Entity
    {
        public string Responsible { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}