using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
	public class CreateEquipmentParameterGroupCommand : ICommand
	{
        public string Name { get; set; }
        public List<EquipmentParameter> Parameters { get; set; }

        public CreateEquipmentParameterGroupCommand()
		{
		}

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

