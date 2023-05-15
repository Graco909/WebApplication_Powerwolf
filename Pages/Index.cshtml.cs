using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Powerwolf.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            var task = client.GetAsync("http://localhost/jsons/News.json");
            var task2 = client.GetAsync("http://localhost/jsons/BandMembers.json");
            var task3 = client.GetAsync("http://localhost/jsons/Concerts.json");
            HttpResponseMessage result = task.Result;
            HttpResponseMessage result2 = task2.Result;
            HttpResponseMessage result3 = task3.Result;
            List<News> news = new List<News>();
            List<BandMembers> bandmembers = new List<BandMembers>();
            List<Concerts> concerts = new List<Concerts>();
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
            if (result3.IsSuccessStatusCode)
            {
                Task<string> readString = result3.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                concerts = Concerts.FromJson(jsonString);
            }
            ViewData["News"] = news;
            ViewData["BandMembers"] = bandmembers;
            ViewData["Concerts"] = concerts;
        }
    }
}