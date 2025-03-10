using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7012/api/Cars/GetLast5CarsWithBrandQueryHandler");
            if (responseMessage.IsSuccessStatusCode)
            {

                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(JsonData);
                return View(values);

            }
            return View(new List<ResultLast5CarsWithBrandsDto>());
        }
    }
}
