namespace MyMovieApi.Core.Models.Requests
{
    public class UpdateMovieRequest
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string Synopsis { get; set; }
        public string ApprovalRating { get; set; }
    }
}