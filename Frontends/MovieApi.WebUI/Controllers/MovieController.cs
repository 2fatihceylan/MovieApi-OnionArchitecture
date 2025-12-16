using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {



        private readonly IHttpClientFactory _httpClientFactory;


        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }




        public async Task<IActionResult> MovieList()
        {


            ViewBag.v1 = "Movie List";
            ViewBag.v2 = "Home Page";
            ViewBag.v3= "All Movies";



            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7216/api/Movie");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var movieDtoList = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);

                return View(movieDtoList);
            }




            return View(); 
        }




        public async Task<IActionResult> MovieDetail(int id)
        {

            //ViewBag.v1 = "Movie List";
            ViewBag.v2 = "Movie List";
            ViewBag.v3 = "Movie Name";


            id = 0;



            return View();
        }




    }
}
