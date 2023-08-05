using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}