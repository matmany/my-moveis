using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAndPassAsync(string email, string password);
    }
}