using System.Threading.Tasks;
using ZenoDcimManager.Domain.ZenoContext.Repositories;

namespace ZenoDcimManager.Domain.ActiveContext.Usecases
{
    public class UpdatePathnameWhenStructureChanges
    {
        private readonly IEquipmentParameterRepository _equipmentParameterRepository;

        public UpdatePathnameWhenStructureChanges(IEquipmentParameterRepository equipmentParameterRepository)
        {
            _equipmentParameterRepository = equipmentParameterRepository;
        }

        public async Task Execute(string oldValue, string newValue)
        {
            var _oldValue = oldValue.Replace(" ","").Trim();
            var _newValue = newValue.Replace(" ", "").Trim();
            var equipmentsToUpdatePathname = await _equipmentParameterRepository.FindParametersContainingName(_oldValue);

            foreach (var equipmentParameter in equipmentsToUpdatePathname)
            {
                equipmentParameter.Pathname = equipmentParameter.Pathname.Replace(_oldValue, _newValue);
                equipmentParameter.TrackModifiedDate();
                _equipmentParameterRepository.Update(equipmentParameter);
            }

            //await _equipmentParameterRepository.Commit();

        }
    }
}