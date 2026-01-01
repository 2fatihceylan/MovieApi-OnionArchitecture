using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Dto.Dtos.AdminCategoryDtos;
using MovieApi.Dto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{



   
    [Area("Admin")]
    public class AdminMovieController : Controller
    {




        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }









        public async Task<IActionResult> MovieList()
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7216/api/Movie");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);

                return View(values);
            }



            return View();
        }





        [HttpGet]
        public async Task<IActionResult> CreateMovie()
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
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateMovie(AdminCreateMovieDto adminCreateMovieDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminCreateMovieDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7216/api/Movie", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }
            return View();
        }






        public async Task<IActionResult> DeleteMovie(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7216/api/Movie?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }

            return View();
        }
    }
}
