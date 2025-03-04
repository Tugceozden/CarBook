using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.AboutViewComponents;
    public class _AboutUsComponentPartial:ViewComponent
    {
    private readonly IHttpClientFactory _httpClientFactory;

    public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync() 
        { 
        var client= _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7234/api/Abouts");
        if(responseMessage.IsSuccessStatusCode)
        {
            var JsonData= await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(JsonData);
            return View(values);
        }
            return View(); 
        } 
    }

