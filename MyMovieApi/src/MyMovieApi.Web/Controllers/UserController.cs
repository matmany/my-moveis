using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieApi.Core.Handlers;
using MyMovieApi.Core.Models.Requests;
using MyMovieApi.Core.Models.Response;

namespace MyMovieApi.Web.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserHandler _handler;
        public UserController(UserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("{userId:long}/movies")]
        public async Task<ActionResult<BaseResponse>> AddMovie([FromRoute] long userId, [FromBody] AddUserMovieRequest request)
        {
            var response = await _handler.AddMovie(userId, request);
            return Ok(response);
        }

        [HttpDelete("{userId:long}/movies/{movieId:long}")]
        public async Task<ActionResult<BaseResponse>> RemoveMovie([FromRoute] long userId, [FromRoute] long movieId)
        {
            var response = await _handler.RemoveMovie(userId, movieId);
            return Ok(response);
        }

        [HttpPut("{userId:long}/movies/{movieId:long}")]
        public async Task<ActionResult<BaseResponse>> UpdateMovie(
            [FromRoute] long userId,
            [FromRoute] long movieId,
            [FromBody] UpdateUserMovieRequest request)
        {
            var response = await _handler.UpdateMovie(userId, movieId, request);
            return Ok(response);
        }

        [HttpGet("{userId:long}/movies/{movieId:long}")]
        public async Task<ActionResult<UserMovieDtoResponse>> GetMovie([FromRoute] long userId, [FromRoute] long movieId)
        {
            var response = await _handler.GetMovie(userId, movieId);
            return Ok(response);
        }

        [HttpGet("{userId:long}/movies")]
        public async Task<ActionResult<IList<UserMovieDtoResponse>>> GetMovies([FromRoute] long userId)
        {
            var response = await _handler.GetMovies(userId);
            return Ok(response);
        }

    }
}