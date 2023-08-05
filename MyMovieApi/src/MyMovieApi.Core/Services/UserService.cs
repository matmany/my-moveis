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
        public async Task<User> GetVerifiedUserOrFail(string email, string password)
        {
            var user = await _repository.GetByEmailAndPassAsync(email, password) ?? throw new ArgumentNullException(UserEnum.EmailOrPasswordIncorret.GetDescription());
            return user;
        }
    }
}