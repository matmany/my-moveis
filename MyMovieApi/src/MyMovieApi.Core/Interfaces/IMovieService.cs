using MyMovieApi.Core.Entities;

namespace MyMovieApi.Core.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> AddAsync(Movie movie);
        Task<bool> UpdateAsync(Movie movie);
        Task<Movie> GetByIdAsync(long id);
        Task<Movie> GetByIdOrFailAsync(long id);
        Task<Movie> GetByIdOrDefaultAsync(long? id);
        Task<IList<Movie>> GetAll();

    }
}