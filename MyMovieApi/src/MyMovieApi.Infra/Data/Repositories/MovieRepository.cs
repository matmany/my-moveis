using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Interfaces;

namespace MyMovieApi.Infra.Data.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}