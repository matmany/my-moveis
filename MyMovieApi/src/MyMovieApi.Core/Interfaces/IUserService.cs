using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetVerifiedUserOrFailAsync(string email, string password);
    }
}