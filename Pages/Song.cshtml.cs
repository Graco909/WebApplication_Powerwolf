﻿using JsonFiles;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Powerwolf.Pages;

public class Song : PageModel
{
    public Songs SelectedSong { get; set; } = new Songs();
    
    public void OnGet(string songId)
    {
        List<Songs> songs = DataAccess.GetSongs();

        SelectedSong = songs.First(x => x.Id == songId);
        
        ViewData["Song"] = SelectedSong;
    }
}