using System;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class EquipmentCardSettingsEditorCommand : ICommand
    {
        public Guid EquipmentId { get; set; }
        public ParameterInfo Parameter1 { get; set; }
        public ParameterInfo Parameter2 { get; set; }
        public ParameterInfo Parameter3 { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}