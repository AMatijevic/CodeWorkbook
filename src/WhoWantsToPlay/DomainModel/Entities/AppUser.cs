using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WhoWantsToPlay.DomainModel.Entities
{
    public class AppUser : IdentityUser<int>
    {
        private ICollection<Play> Plays { get; } = new List<Play>();
    }
}
