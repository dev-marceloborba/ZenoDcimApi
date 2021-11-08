using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Domain.UserContext.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}