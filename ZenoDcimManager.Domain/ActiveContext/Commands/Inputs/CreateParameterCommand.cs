﻿using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateParameterCommand : ICommand
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int LowLimit { get; set; }
        public int HighLimit { get; set; }
        public int Scale { get; set; }

        public CreateParameterCommand()
        {
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

