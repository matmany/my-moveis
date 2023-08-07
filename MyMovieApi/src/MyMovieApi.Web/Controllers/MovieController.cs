using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieApi.Core.Handlers;
using MyMovieApi.Core.Models.Requests;
using MyMovieApi.Core.Models.Response;

namespace MyMovieApi.Web.Controllers
{
    [Route("api/movies")]
    [Authorize]
    public class MovieController : Controller
    {
        private readonly MovieHandler _handler;

        public MovieController(MovieHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateMovieRequest request)
        {
            var response = await _handler.Create(request);
            return Ok(response);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateMovieRequest request, [FromRoute] long id)
        {
            var response = await _handler.Update(request, id);
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<MovieDtoResponse>> Get([FromRoute] long id)
        {
            var response = await _handler.Get(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IList<MovieDtoResponse>>> GetAll()
        {
            var response = await _handler.GetAll();
            return Ok(response);
        }
    }
}