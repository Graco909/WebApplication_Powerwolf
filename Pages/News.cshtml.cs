using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;

namespace WebApplication_Powerwolf.Pages
{
    public class NewsModel : PageModel
    {
        public void OnGet()
        {
            List<News> news = DataAccess.GetNews();

            ViewData["News"] = news;
        }
    }
}
