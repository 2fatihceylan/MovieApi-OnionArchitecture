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

        private GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private GetMovieQueryHandler _getMovieQueryHandler;
        private CreateMovieCommandHandler _createMovieCommandHandler;
        private UpdateMovieCommandHandler _updateMovieCommandHandler;
        private RemoveMovieCommandHandler   _removeMovieCommandHandler;
        private GetMovieWithCategoryQueryHandler _getMovieWithCategoryQueryHandler;
        public MovieController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, 
            GetMovieQueryHandler getMovieQueryHandler, 
            CreateMovieCommandHandler createMovieCommandHandler, 
            UpdateMovieCommandHandler updateMovieCommandHandler, 
            RemoveMovieCommandHandler removeMovieCommandHandler,
            GetMovieWithCategoryQueryHandler getMovieWithCategoryQueryHandler
            )
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _getMovieWithCategoryQueryHandler = getMovieWithCategoryQueryHandler;
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




        [HttpGet("GetMovieWithCategory")]
        public async Task<IActionResult> GetMovieWithCategory()
        {
            var value = await _getMovieWithCategoryQueryHandler.Handle();

            return Ok(value);
        }
    }
}
