using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;

namespace MovieApi.WebUI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRateComponentPartial : ViewComponent
    {



        public IViewComponentResult Invoke(ResultMovieDto resultMovieDto)
        {
            return View(resultMovieDto);
        }
    }
}
