using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Commands
{
    public class CreateSupplierCommand : ICommand
    {
        public string Responsible { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}