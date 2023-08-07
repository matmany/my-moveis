namespace MyMovieApi.Core.Models.Response
{
    public class UserMovieDtoResponse : MovieDtoResponse
    {
        public string UserRating { get; set; }
        public bool Watched { get; set; }
    }
}