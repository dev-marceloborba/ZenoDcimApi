using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateEquipmentOnGroupCommand : ICommand
    {
        public Guid GroupId { get; set; }
        public List<ParameterAssociation> Parameters { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ParameterAssociation
    {
        public Guid Id { get; set; }
    }
}