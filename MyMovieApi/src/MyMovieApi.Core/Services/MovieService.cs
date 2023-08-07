using Core.Helpers;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Enums;
using MyMovieApi.Core.Interfaces;

namespace MyMovieApi.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public MovieService()
        {
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            return await _repository.AddAsync(movie);
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            return await _repository.UpdateAsync(movie);
        }

        public async Task<IList<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Movie> GetByIdOrFailAsync(long id)
        {
            var movie = await GetByIdAsync(id) ?? throw new ArgumentException(MovieEnum.NotFound.GetDescription());
            return movie;
        }
    }
}