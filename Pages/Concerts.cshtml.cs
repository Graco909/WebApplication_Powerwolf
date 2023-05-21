using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Powerwolf.Pages
{
    public class ConcertsModel : PageModel
    {
        public void OnGet()
        {
            List<Concerts> concerts = DataAccess.GetConcerts();
            
            ViewData["Concerts"] = concerts;
        }
    }
}
