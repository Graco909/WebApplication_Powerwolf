﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;
namespace WebApplication_Powerwolf.Pages;

public class MusicModel : PageModel
{
    public void OnGet()
    {
        List<Songs> songs = DataAccess.GetSongs();

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