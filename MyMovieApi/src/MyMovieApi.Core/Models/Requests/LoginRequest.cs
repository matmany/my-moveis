using System.Text.Json.Serialization;

namespace MyMovieApi.Core.Models.Requests
{
    public class LoginRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}