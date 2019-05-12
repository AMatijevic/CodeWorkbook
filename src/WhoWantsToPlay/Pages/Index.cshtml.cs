using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhoWantsToPlay.Data;
using WhoWantsToPlay.DomainModel.Entities;

namespace WhoWantsToPlay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly UserManager<AppUser> _UserManager;

        public List<PlaygroundModel> Playgrounds;

        public IndexModel(ApplicationDbContext applicationDbContext, UserManager<AppUser> userManager)
        {
            _DbContext = applicationDbContext;
            _UserManager = userManager;
            Playgrounds = new List<PlaygroundModel>();
        }

        public async Task OnGet()
        {
            //Moram citati iz baze igraliste za sada samo jedno i koji su sve ljudi rekli da ce doc na kosarku
            //Sto zelis da se prikaze koje podatke zelis na view modelu
            //Moram imati buttone da mogu rec da doci cu ili necu
            //Ali ako si rekao vec da ces doc onda imas samo za kliknuti ne 
            var playgrounds = await _DbContext.Playgrounds.ToListAsync();
            var plays = await _DbContext.Plays.Include(p => p.AppUser).Include(p => p.Playground).ToListAsync();

            Playgrounds = (await Task.WhenAll(playgrounds.Select(async p => 
            {
                var playground = new PlaygroundModel { Id = p.Id, Name = p.Name, StartTime = p.StartTime.ToShortTimeString() };
                var users = plays.Where(play => play.PlaygroundId == p.Id && play.PlayDate.Date == DateTime.Now.Date);
                if (users != null && users.Any())
                {
                    foreach(var user in users)
                    {
                        var claims = await _UserManager.GetClaimsAsync(user.AppUser);
                        playground.Players.Add(new PlayerModel { Id = user.AppUser.Id, Name = user.AppUser.UserName, Image = claims.FirstOrDefault(c=>c.Type=="image").Value });
                    }
                }
                return playground;
            }))).ToList();





          
            
        }
    }

    public class PlaygroundModel
    {
        public PlaygroundModel()
        {
            Players = new List<PlayerModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public List<PlayerModel> Players { get; set; }
    }

    public class PlayerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
