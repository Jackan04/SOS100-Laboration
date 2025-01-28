using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using Newtonsoft.Json;

namespace MyWebApp.Controllers;

public class LocationController : Controller
{
    private readonly HttpClient _httpClient;
    
    public LocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LocationApi");
    }

    public async Task<IActionResult> Index()
    {
        
        
            var response = await _httpClient.GetAsync("api/Location");

        
                var jsonString = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<Location>>(jsonString);

                return View(locations); 
            
        
        
  
    }
}