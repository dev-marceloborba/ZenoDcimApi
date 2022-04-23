using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
	public class CreateSiteCommand : ICommand
	{
        public string Name { get; set; }

        public CreateSiteCommand()
		{
		}

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

