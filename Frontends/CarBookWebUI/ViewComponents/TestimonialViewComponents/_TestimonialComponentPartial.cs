using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("");
         if(responseMessage.IsSuccessStatusCode) 
            {

                var JsonData= await responseMessage.Content.ReadAsStringAsync();  
                var values=JsonConvert.DeserializeObject<List<string>>(JsonData);   
                return View(values);

            }
         return View();
        }
    }
}
