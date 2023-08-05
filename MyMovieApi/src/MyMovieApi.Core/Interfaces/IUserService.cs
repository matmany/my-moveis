using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetVerifiedUserOrFail(string email, string password);
    }
}