using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhoWantsToPlay.Data;

namespace WhoWantsToPlay.Pages.Play
{
    using WhoWantsToPlay.DomainModel.Entities;

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _DbContext;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
        }

        //public void OnGet()
        //{

        //}

        public async Task<IActionResult> OnGetAssignAsync(int playgroundId, DateTime date)
        {
            //Assign current user on that play that is define with playground and date
            _DbContext.Plays.Add(new Play(playgroundId, 1, date));
            await _DbContext.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}