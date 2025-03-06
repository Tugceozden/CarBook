using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using CarBook.Dto.BannerDtos;

namespace CarBookWebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7012/api/Banners");

            if (responseMessage.IsSuccessStatusCode)
            {

                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(JsonData);
                return View(values);

            }
            return View(new List<ResultBannerDto>());
        }

    }
       
            
}
