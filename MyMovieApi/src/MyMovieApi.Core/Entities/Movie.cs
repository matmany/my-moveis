namespace MyMovieApi.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string Synopsis {get; set; }
        public string ApprovalRating{get; set; }
        public string DataOrigin { get; set; }
    }
}