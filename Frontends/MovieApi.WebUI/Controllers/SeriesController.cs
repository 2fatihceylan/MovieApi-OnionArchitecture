using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.SeriesDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class SeriesController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;


        public SeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> SeriesList()
        {


            ViewBag.v1 = "Series List";
            ViewBag.v2 = "Home Page";
            ViewBag.v3 = "All Series";


            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7216/api/Serieses");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var seriesDtoList = JsonConvert.DeserializeObject<List<ResultSeriesDto>>(jsonData);

                return View(seriesDtoList);
            }


            return View();
        }





        public async Task<IActionResult> SeriesDetail(int id)
        {
            ViewBag.v2 = "Series List";
            ViewBag.v3 = "Series Name";


            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7216/api/Serieses/GetSeries?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var series = JsonConvert.DeserializeObject<ResultSeriesDto>(jsonData);

                return View(series);
            }

            return View();
        }



    }
}
