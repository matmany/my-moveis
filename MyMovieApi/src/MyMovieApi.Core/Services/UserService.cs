using System.Linq.Expressions;
using Core.Helpers;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Enums;
using MyMovieApi.Core.Interfaces;

namespace MyMovieApi.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> GetByIdOrFailAsync(long id)
        {
            var user = _repository.GetByIdAsync(id) ?? throw new ArgumentException(UserEnum.NotFound.GetDescription());
            return user;
        }

        public Task<User> GetByIdOrFailAsync(long id, params Expression<Func<User, object>>[] includes)
        {
            var user = _repository.GetByIdAsync(id, includes) ?? throw new ArgumentException(UserEnum.NotFound.GetDescription());
            return user;
        }

        public async Task<User> GetVerifiedUserOrFailAsync(string email, string password)
        {
            var user = await _repository.GetByEmailAndPassAsync(email, password) ?? throw new ArgumentException(UserEnum.EmailOrPasswordIncorret.GetDescription());
            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            return await _repository.AddAsync(user);
        }

        public async Task<UserMovie> AddMovie(User user, Movie request, UserMovie userMovie)
        {
            if (request.Id <= 0)
            {
                await AddNewMovie(request, userMovie);
                return userMovie;
            }

            userMovie.MovieId = request.Id;

            await _repository.AddMovieAsync(userMovie);
            return userMovie;
        }

        private async Task<UserMovie> AddNewMovie(Movie request, UserMovie newUserMovie)
        {
            await _repository.AddMovieNewTransaction(request, newUserMovie);
            return newUserMovie;
        }
    }
}