using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateEquipmentParameterGroupCommand : ICommand
    {
        public string Name { get; set; }
        public EEquipmentGroup Group { get; set; }
        public List<Guid> ParametersId { get; set; } = new List<Guid>();

        public CreateEquipmentParameterGroupCommand()
        {
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

