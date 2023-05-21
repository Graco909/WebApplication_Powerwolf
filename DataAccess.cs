using JsonFiles;

namespace WebApplication_Powerwolf;

public static class DataAccess
{
    public static List<BandMembers> GetBandMembers()
    {
        HttpClient client = new HttpClient();

        List<BandMembers> output = new List<BandMembers>();

        var task = client.GetAsync("http://localhost/jsons/BandMembers.json");
        HttpResponseMessage result = task.Result;

        if (result.IsSuccessStatusCode)
        {
            Task<string> readString = result.Content.ReadAsStringAsync();
            string jsonString = readString.Result;
            output = BandMembers.FromJson(jsonString);
        }

        return output;
    }

    public static List<Concerts> GetConcerts()
    {
        HttpClient client = new HttpClient();

        List<Concerts> output = new List<Concerts>();

        var task = client.GetAsync("http://localhost/jsons/Concerts.json");
        HttpResponseMessage result = task.Result;
        if (result.IsSuccessStatusCode)
        {
            Task<string> readString = result.Content.ReadAsStringAsync();
            string jsonString = readString.Result;
            output = Concerts.FromJson(jsonString);
        }

        return output;
    }

    public static List<News> GetNews()
    {
        HttpClient client = new HttpClient();

        List<News> output = new List<News>();

        var task = client.GetAsync("http://localhost/jsons/News.json");
        HttpResponseMessage result = task.Result;
        if (result.IsSuccessStatusCode)
        {
            Task<string> readString = result.Content.ReadAsStringAsync();
            string jsonString = readString.Result;
            output = News.FromJson(jsonString);
        }

        return output;
    }

    public static List<Songs> GetSongs()
    {
        HttpClient client = new HttpClient();

        List<Songs> output = new List<Songs>();

        var task = client.GetAsync("http://localhost/jsons/Songs.json");
        HttpResponseMessage result = task.Result;

        if (result.IsSuccessStatusCode)
        {
            Task<string> readString = result.Content.ReadAsStringAsync();
            string jsonString = readString.Result;
            output = Songs.FromJson(jsonString);
        }

        return output;
    }
}