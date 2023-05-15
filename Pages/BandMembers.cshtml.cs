using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;

namespace WebApplication_Powerwolf.Pages
{
    public class BandMembersModel : PageModel
    {
        readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            var task = client.GetAsync("http://localhost/jsons/BandMembers.json");
            HttpResponseMessage result = task.Result;
            List<BandMembers> bandmembers = new List<BandMembers>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                bandmembers = BandMembers.FromJson(jsonString);
            }
            ViewData["BandMembers"] = bandmembers;
        }
        public void OnReload() { 
        
        }
    }
}
