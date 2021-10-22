using EvoDcimManager.Domain.UserContext.Entities;

namespace EvoDcimManager.Domain.UserContext.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}