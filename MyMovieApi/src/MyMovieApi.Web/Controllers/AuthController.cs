using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieApi.Core.Handlers;
using MyMovieApi.Core.Helper;
using MyMovieApi.Core.Models.Requests;
using MyMovieApi.Core.Models.Response;

namespace MyMovieApi.Web.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly AuthHandler _authHandler;
        public AuthController(AuthHandler authHandler)
        {
            _authHandler = authHandler;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Login([FromBody]LoginRequest request)
        {
            var response = await _authHandler.Login(request);
            return Ok(response);
        }
    }
}