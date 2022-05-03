using System.Threading.Tasks;

namespace ZenoDcimManager.Shared.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}