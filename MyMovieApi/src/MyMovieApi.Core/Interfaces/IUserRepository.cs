using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAndPassAsync(string email, string password);
        Task<UserMovie> AddMovieNewTransaction(Movie newMovie, UserMovie userMovie);
        Task<UserMovie> AddMovieAsync(UserMovie userMovie);
    }
}