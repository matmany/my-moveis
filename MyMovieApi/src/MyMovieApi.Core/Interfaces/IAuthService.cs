namespace MyMovieApi.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(object user);
    }
}