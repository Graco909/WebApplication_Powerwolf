using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;
namespace WebApplication_Powerwolf.Pages;

public class MusicModel : PageModel
{
    readonly HttpClient client = new HttpClient();
    public void OnGet()
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

        List<string> albums = new List<string>();

        foreach (Songs song in songs)
        {
            if (!albums.Contains(song.Album))
            {
                albums.Add(song.Album);
            }
        }

            
        ViewData["Songs"] = songs;
        ViewData["Albums"] = albums;
    }
}