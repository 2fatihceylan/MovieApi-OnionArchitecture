using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        GetSeriesQueryHandler _getSeriesQueryHandler;
        CreateSeriesCommandHandler _createSeriesCommandHandler;
        UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        RemoveSeriesCommandHandler _removeSeriesCommandHandler;


        public SeriesesController(GetSeriesByIdQueryHandler getSeriesByIdQueryHandler,
            GetSeriesQueryHandler getSeriesQueryHandler,
            CreateSeriesCommandHandler createSeriesCommandHandler,
            UpdateSeriesCommandHandler updateSeriesCommandHandler,
            RemoveSeriesCommandHandler removeSeriesCommandHandler)
        {
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _getSeriesQueryHandler = getSeriesQueryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
        }





        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var value = await _getSeriesQueryHandler.Handle();

            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handle(command);

            return Ok("Series Created.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id));

            return Ok("Series Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {
            await _updateSeriesCommandHandler.Handle(command);

            return Ok("Series Updated");
        }


        [HttpGet("GetSeries")]
        public async Task<IActionResult> GetSeriesById(int id)
        {
            var value = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id));

            return Ok(value);
        }



    }
}
