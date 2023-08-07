namespace MyMovieApi.Core.Models.Response
{
    public class MovieDtoResponse
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string Synopsis { get; set; }
        public string ApprovalRating { get; set; }
    }
}