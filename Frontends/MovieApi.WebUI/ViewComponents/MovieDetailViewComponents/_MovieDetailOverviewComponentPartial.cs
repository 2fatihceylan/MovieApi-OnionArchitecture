using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;

namespace MovieApi.WebUI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailOverviewComponentPartial : ViewComponent
    {



        public IViewComponentResult Invoke(ResultMovieDto resultMovieDto)
        {
            return View(resultMovieDto); 
        }
    }
}
