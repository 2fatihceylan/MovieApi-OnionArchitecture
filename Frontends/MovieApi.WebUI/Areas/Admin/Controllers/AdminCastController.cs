using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminCastDtos;
using Newtonsoft.Json;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminCastController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }




        public async Task<IActionResult> CastList()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7216/api/Casts");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<AdminResultCastDto>>(jsonData);


                return View(values);
            }


            return View();

        }




        [HttpGet]
        public IActionResult CreateCast()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(AdminCreateCastDto adminCreateCastDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(adminCreateCastDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7216/api/Casts", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CastList");
            }

            return View();
        }






        public async Task<IActionResult> DeleteCast(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7216/api/Casts?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CastList");
            }


            return View();
        }

    }
}
