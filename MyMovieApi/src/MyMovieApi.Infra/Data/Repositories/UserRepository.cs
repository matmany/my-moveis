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

        public async Task<UserMovie> AddMovieAsync(UserMovie userMovie)
        {
            await _dbContext.UserMovies.AddAsync(userMovie);
            await _dbContext.SaveChangesAsync();
            return userMovie;
        }

        public async Task<UserMovie> AddMovieNewTransaction(Movie newMovie, UserMovie userMovie)
        {
            await using var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.Movies.AddAsync(newMovie);
                await _dbContext.SaveChangesAsync();

                userMovie.MovieId = newMovie.Id;
                await _dbContext.UserMovies.AddAsync(userMovie);
                await _dbContext.SaveChangesAsync();

                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error ao salvar salvar filme");
            }
            return userMovie;
        }
    }
}