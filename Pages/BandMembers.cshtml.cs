using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JsonFiles;

namespace WebApplication_Powerwolf.Pages
{
    public class BandMembersModel : PageModel
    {
        public void OnGet()
        {
            List<BandMembers> bandMembers = DataAccess.GetBandMembers();

            ViewData["BandMembers"] = bandMembers;
        }
        public void OnReload() { 
        
        }
    }
}
