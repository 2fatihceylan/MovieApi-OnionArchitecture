using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminCategoryDtos;
using MovieApi.Dto.Dtos.AdminMovieDtos;
using MovieApi.Dto.Dtos.AdminSeriesDto;
using Newtonsoft.Json;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSeriesController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;


        public AdminSeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }





        public async Task<IActionResult> SeriesList()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7216/api/Serieses/GetSeriesWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<AdminResultSeriesDto>>(jsonData);

                return View(values);
            }

            return View();
        }








        [HttpGet]
        public async Task<IActionResult> CreateSeries()
        {
            var client = _httpClientFactory.CreateClient();
            List<SelectOptionCategoryDto> categories = new List<SelectOptionCategoryDto>();

            try
            {
                var responseMessage = await client.GetAsync("https://localhost:7216/api/Categories");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SelectOptionCategoryDto>>(jsonData);
                    categories = values ?? new List<SelectOptionCategoryDto>();
                }
                else
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    ViewBag.ErrorMessage = $"Kategori alınamadı. Durum: {(int)responseMessage.StatusCode} { responseMessage.ReasonPhrase}. İçerik: { errorContent}";
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = $"Kategori çağrısı sırasında hata oluştu: {ex.Message}";
            }

            if(categories == null || !categories.Any())
            {
                categories = new List<SelectOptionCategoryDto>
                {
                    new SelectOptionCategoryDto { CategoryId = 1, CategoryName = "Ball" },
                    new SelectOptionCategoryDto { CategoryId = 2, CategoryName = "Hat" }
                };
            }

            ViewBag.Categories = categories;

            return View();


        }






        [HttpPost]
        public async Task<IActionResult> CreateSeries(AdminCreateSeriesDto adminCreateSeriesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminCreateSeriesDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7216/api/Serieses", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");

            }

            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateSeries(int id)
        {

            var client = _httpClientFactory.CreateClient();
            List<SelectOptionCategoryDto> categories = new List<SelectOptionCategoryDto>();

            try
            {
                var responseMessage = await client.GetAsync("https://localhost:7216/api/Categories");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SelectOptionCategoryDto>>(jsonData);
                    categories = values ?? new List<SelectOptionCategoryDto>();
                }
                else
                {
                    // İsteğin başarısız olduğu durumda hata içeriğini okuyup gösterim için saklayabilirsiniz.
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    ViewBag.ErrorMessage = $"Kategori alınamadı. Durum: {(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}. İçerik: {errorContent}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Kategori çağrısı sırasında hata oluştu: {ex.Message}";
            }

            // Eğer uzaktan veri yoksa veya boşsa bir yedek liste kullan.
            if (categories == null || !categories.Any())
            {
                categories = new List<SelectOptionCategoryDto>
                {
                    new SelectOptionCategoryDto { CategoryId = 1, CategoryName = "Ball" },
                    new SelectOptionCategoryDto { CategoryId = 2, CategoryName = "Hat" }
                };
            }

            ViewBag.Categories = categories;




            var responseMessageMovie = await client.GetAsync("https://localhost:7216/api/Serieses/GetSeries?id=" + id);

            if (responseMessageMovie.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageMovie.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<AdminUpdateSeriesDto>(jsonData);
                return View(value);
            }


            return View();


        }


        [HttpPost]
        public async Task<IActionResult> UpdateSeries(AdminUpdateSeriesDto adminUpdateSeriesDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminUpdateSeriesDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7216/api/Serieses", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }
            return View();

        }



        [HttpGet]
        public async Task<IActionResult> SeriesDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessageSeries = await client.GetAsync("https://localhost:7216/api/Serieses/GetSeries?id=" + id);

            if (responseMessageSeries.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageSeries.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<AdminResultSeriesDto>(jsonData);
                return View(value);
            }
            return View();
        }





        public async Task<IActionResult> DeleteSeries(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7216/api/Serieses?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }

            return View();
        }


    }
}
