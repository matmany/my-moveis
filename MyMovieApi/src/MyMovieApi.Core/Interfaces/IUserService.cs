using System.Linq.Expressions;
using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetVerifiedUserOrFailAsync(string email, string password);
        Task<User> GetByIdOrFailAsync(long id);
        Task<User> GetByIdOrFailAsync(long id, params Expression<Func<User, object>>[] includes);
        Task<User> AddAsync(User user);
        Task<UserMovie> AddMovie(UserMovie newUserMovie);
    }
}