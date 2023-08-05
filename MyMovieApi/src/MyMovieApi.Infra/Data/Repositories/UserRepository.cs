using Microsoft.EntityFrameworkCore;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Interfaces;

namespace MyMovieApi.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmailAndPassAsync(string email, string password)
        {
            var query = _dbContext.Users.Where(u => u.Email == email && u.Password == password);
            return await query.FirstOrDefaultAsync();
        }
    }
}