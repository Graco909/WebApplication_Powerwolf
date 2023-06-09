using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;

namespace WebApplication_Powerwolf.Pages
{
    public class testModel : PageModel
    {
        readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            var task = client.GetAsync("http://localhost/jsons/News.json");
            var task2 = client.GetAsync("http://localhost/jsons/BandMembers.json");
            HttpResponseMessage result = task.Result;
            HttpResponseMessage result2 = task2.Result;
            List<News> news = new List<News>();
            List<BandMembers> bandmembers = new List<BandMembers>();
            if (result.IsSuccessStatusCode) 
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                news = News.FromJson(jsonString);
            }
            if (result2.IsSuccessStatusCode)
            {
                Task<string> readString = result2.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                bandmembers = BandMembers.FromJson(jsonString);
            }
            ViewData["News"] = news;
            ViewData["BandMembers"] = bandmembers;
        }
    }
}
