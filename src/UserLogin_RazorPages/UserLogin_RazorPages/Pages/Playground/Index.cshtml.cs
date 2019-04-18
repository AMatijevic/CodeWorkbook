using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserLogin_RazorPages.Pages.Playground
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetAssignAsync(int id)
        {
            //await _userService.ResetDisplayName(User);
            if (User != null)
            {
                var playground = DataAccess.Data.Playgrounds.FirstOrDefault(p => p.Id == id);
                playground.Users.Add(new DomainModel.Entities.User { Email = "Bla" });
            }

            return RedirectToPage("/Index");
        }
    }
}