using System.Threading.Tasks;

namespace ZenoDcimManager.Shared.Helpers
{
    public interface ICheckIfExists
    {
        Task<bool> CheckIfExists(string parameter);
    }
}