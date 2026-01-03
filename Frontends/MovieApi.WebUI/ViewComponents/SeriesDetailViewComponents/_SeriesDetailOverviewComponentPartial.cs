using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.SeriesDtos;

namespace MovieApi.WebUI.ViewComponents.SeriesDetailViewComponents
{
    public class _SeriesDetailOverviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(ResultSeriesDto resultSeriesDto)
        {
            return View(resultSeriesDto);
        }
    }
}
