using AutoMapper;
using MyMovieApi.Core.Entities;
using MyMovieApi.Core.Models.Requests;

namespace MyMovieApi.Core.Mapping
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<CreateMovieRequest, Movie>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AddUserMovieRequest, UserMovie>();
            CreateMap<UpdateMovieRequest, Movie>();
        }
    }
}