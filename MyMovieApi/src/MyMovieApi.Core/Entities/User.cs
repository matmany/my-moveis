namespace MyMovieApi.Core.Entities
{
    public class User : BaseEntity
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
    }
}