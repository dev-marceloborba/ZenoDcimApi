using System;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class SiteBuildingCardSettingsEditorCommand : ICommand
    {
        public Guid SiteId { get; set; }
        public Guid BuildingId { get; set; }
        public ParameterInfo Parameter1 { get; set; }
        public ParameterInfo Parameter2 { get; set; }
        public ParameterInfo Parameter3 { get; set; }
        public ParameterInfo Parameter4 { get; set; }
        public ParameterInfo Parameter5 { get; set; }
        public ParameterInfo Parameter6 { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}