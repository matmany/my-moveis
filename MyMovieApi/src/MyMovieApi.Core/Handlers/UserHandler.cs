using AutoMapper;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Enums;
using MyMovieApi.Core.Helper;
using MyMovieApi.Core.Interfaces;
using MyMovieApi.Core.Models.Requests;
using MyMovieApi.Core.Models.Response;
using Serilog;

namespace MyMovieApi.Core.Handlers
{
    public class UserHandler
    {
        private readonly IUserService _userService;
        private readonly IMovieService _moveService;
        private readonly IMapper _mapper;
        public UserHandler(
            IUserService userService,
            IMovieService moveService,
            IMapper mapper)
        {
            _userService = userService;
            _moveService = moveService;
            _mapper = mapper;
        }

        public async Task<Result<BaseResponse>> AddMovie(long userId, AddUserMovieRequest request)
        {
            var result = new Result<BaseResponse>();

            try
            {
                var user = await _userService.GetByIdOrFailAsync(userId, u => u.UserMovies);
                var movie = _mapper.Map<Movie>(request);
                var userMovie = _mapper.Map<UserMovie>(request);
                await _userService.AddMovie(user, movie, userMovie);
                result.Value = new BaseResponse()
                {
                    Message = UserEnum.MovieAdded.GetDescription()
                };
            }
            catch (Exception ex)
            {

                Log.Error(ex, "<{EventoId}> - Falha adicionar filme ao usuário", this.GetType().Name);
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<Result<UserMovieDtoResponse>> GetMovie(long userId, long movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IList<UserMovieDtoResponse>>> GetMovies(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<BaseResponse>> RemoveMovie(long userId, long movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<BaseResponse>> UpdateMovie(long userId, long movieId, UpdateUserMovieRequest request)
        {
            throw new NotImplementedException();
        }
    }
}