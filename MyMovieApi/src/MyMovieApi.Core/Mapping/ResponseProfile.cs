using AutoMapper;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Models.Response;

namespace MyMovieApi.Core.Mapping
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Movie, MovieDtoResponse>();
        }
    }
}