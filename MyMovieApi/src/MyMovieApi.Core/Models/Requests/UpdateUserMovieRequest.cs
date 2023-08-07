namespace MyMovieApi.Core.Models.Requests
{
    public class UpdateUserMovieRequest
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public string UserRating { get; set; }
        public bool Watched { get; set; }

    }
}