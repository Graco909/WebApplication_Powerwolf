using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;

namespace WebApplication_Powerwolf.Pages
{
    public class NewsModel : PageModel
    {
        readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            var task = client.GetAsync("http://localhost/jsons/News.json");
            HttpResponseMessage result = task.Result;
            List<News> news = new List<News>();
            if (result.IsSuccessStatusCode) 
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                news = News.FromJson(jsonString);
            }
            ViewData["News"] = news;
        }
    }
}
