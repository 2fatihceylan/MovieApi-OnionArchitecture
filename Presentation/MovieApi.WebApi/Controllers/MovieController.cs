using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MoveCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        GetMovieQueryHandler _getMovieQueryHandler;
        CreateMovieCommandHandler _createMovieCommandHandler;
        UpdateMovieCommandHandler _updateMovieCommandHandler;
        RemoveMovieCommandHandler   _removeMovieCommandHandler;

        public MovieController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, 
            GetMovieQueryHandler getMovieQueryHandler, 
            CreateMovieCommandHandler createMovieCommandHandler, 
            UpdateMovieCommandHandler updateMovieCommandHandler, 
            RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }




        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }



        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);

            return Ok("Movie created.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));

            return Ok("Movie deleted.");
        }



        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Movie Updated.");
        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovieById(int id) {

            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }

    }
}
