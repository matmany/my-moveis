using AutoMapper;
using Core.Helpers;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Enums;
using MyMovieApi.Core.Helper;
using MyMovieApi.Core.Interfaces;
using MyMovieApi.Core.Models.Requests;
using MyMovieApi.Core.Models.Response;
using Serilog;

namespace MyMovieApi.Core.Handlers
{
    public class MovieHandler
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _service;
        public MovieHandler(
            IMovieService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Result<BaseResponse>> Create(CreateMovieRequest request)
        {
            var result = new Result<BaseResponse>();

            //TODO: Adicionar validação

            try
            {
                var movie = _mapper.Map<Movie>(request);
                await _service.AddAsync(movie);
                result.Value = new BaseResponse()
                {
                    Message = MovieEnum.Created.GetDescription()
                };

            }
            catch (Exception ex)
            {
                Log.Error(ex, "<{EventoId}> - Falha ao criar filme", this.GetType().Name);
                result.WithError(ex.Message);
            }
            return result;
        }

        public async Task<Result<BaseResponse>> Update(UpdateMovieRequest request, long id)
        {
            var result = new Result<BaseResponse>();

            //TODO: Adicionar validação

            try
            {
                var movie = await _service.GetByIdAsync(id);
                _mapper.Map(request, movie);
                await _service.UpdateAsync(movie);
                result.Value = new BaseResponse()
                {
                    Message = MovieEnum.Updated.GetDescription()
                };

            }
            catch (Exception ex)
            {
                Log.Error(ex, "<{EventoId}> - Falha ao criar filme", this.GetType().Name);
                result.WithError(ex.Message);
            }
            return result;
        }

        public async Task<Result<MovieDtoResponse>> Get(long id)
        {
            var result = new Result<MovieDtoResponse>();
            try
            {
                var movie = await _service.GetByIdAsync(id);
                result.Value = _mapper.Map<MovieDtoResponse>(movie);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "<{EventoId}> - Falha ao atuaizar filme", this.GetType().Name);
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<Result<IList<MovieDtoResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}