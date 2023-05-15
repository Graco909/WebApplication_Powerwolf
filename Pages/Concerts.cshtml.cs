using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Powerwolf.Pages
{
    public class ConcertsModel : PageModel
    {
        readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            var task = client.GetAsync("http://localhost/jsons/Concerts.json");
            HttpResponseMessage result = task.Result;
            List<Concerts> concerts = new List<Concerts>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                concerts = Concerts.FromJson(jsonString);
            }
            ViewData["Concerts"] = concerts;
        }
    }
}
