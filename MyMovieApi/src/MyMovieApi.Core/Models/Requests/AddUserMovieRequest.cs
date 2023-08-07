namespace MyMovieApi.Core.Models.Requests
{
    public class AddUserMovieRequest : CreateMovieRequest
    {
        public long? MovieId { get; set; }
        public long UserId { get; set; }
        public string UserRating { get; set; }
        public bool Watched { get; set; }
    }
}