using DotNetTraining.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetTraining.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public BlogController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
        {
            var model = new BlogListResponseModel();
            var response = await _httpClient.GetAsync(_configuration.GetSection("ApiUrl").Value + $"api/blogs?PageNo={pageNo}&PageSize={pageSize}");

            //if (!response.IsSuccessStatusCode)
            //{
            //    var jsonStr = await response.Content.ReadAsStringAsync();
            //    model = JsonConvert.DeserializeObject<BlogListResponseModel>(jsonStr);
            //    return View(model);
            //}

            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<BlogListResponseModel>(jsonStr);
                return View("BlogIndex", model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
