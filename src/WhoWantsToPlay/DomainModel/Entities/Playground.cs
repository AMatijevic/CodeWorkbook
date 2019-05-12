using System;
using System.Collections.Generic;
using System.Linq;

namespace WhoWantsToPlay.DomainModel.Entities
{
    public class Playground : BaseEntity
    {
        public string Name { get; private set; }

        private ICollection<Play> Plays { get; } = new List<Play>();

        public DateTime StartTime { get; private set; }

        public IEnumerable<AppUser> Users => Plays.Select(p => p.AppUser);


    }
}
