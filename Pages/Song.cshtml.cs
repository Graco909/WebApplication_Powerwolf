using JsonFiles;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Powerwolf.Pages;

public class Song : PageModel
{
    readonly HttpClient client = new HttpClient();

    public Songs SelectedSong { get; set; }
    
    public void OnGet(string songId)
    {
        var task = client.GetAsync("http://localhost/jsons/Songs.json");
        HttpResponseMessage result = task.Result;
        List<Songs> songs = new List<Songs>();
        
        if (result.IsSuccessStatusCode)
        {
            Task<string> readString = result.Content.ReadAsStringAsync();
            string jsonString = readString.Result;
            songs = Songs.FromJson(jsonString);
        }

        SelectedSong = songs.First(x => x.Id == songId);
        
        ViewData["Song"] = SelectedSong;
    }
}