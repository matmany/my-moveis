namespace MyMovieApi.Core.Entities
{
    public class UserMovie
    {
        public string UserRating { get; set; }
        public bool Watched {get; set;} 
        public long UserId { get; set; }
        public User User { get; set; }

        public long MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}