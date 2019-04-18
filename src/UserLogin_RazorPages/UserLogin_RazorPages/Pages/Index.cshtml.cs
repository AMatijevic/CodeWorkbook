using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserLogin_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public DateTime Date { get; set; }
        public List<DomainModel.Entities.Playground> Playgrounds { get; set; }
       

        public void OnGet()
        {
            Date = DateTime.Now.Date;
            Playgrounds = DataAccess.Data.Playgrounds;
        }

    }
}
