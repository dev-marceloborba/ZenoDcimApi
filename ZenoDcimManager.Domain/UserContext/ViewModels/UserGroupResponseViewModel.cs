using System;
using ZenoDcimManager.Domain.UserContext.ValueObjects;

namespace ZenoDcimManager.Domain.UserContext.ViewModels
{
    public class UserGroupResponseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionPermissions Actions { get; set; }
        public RegisterPermissions Registers { get; set; }
        public ViewPermissions Views { get; set; }

    }
}