using HireACar.Dto.APIDtos;
using HireACar.Dto.ServiceDtos;
using HireACar.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HireACar.UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public ServiceController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5081/api/Services");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var responsedata = JsonConvert.DeserializeObject<APIResponseDto>(jsonData);
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(responsedata.Data.ToString());
                return View(values);
            }
            return View();
        }
    }
}
