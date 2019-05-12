using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsToPlay.DomainModel.Entities
{
    public class Play : BaseEntity
    {
        private Play()
        {

        }

        public Play(int playgroundId, int userId, DateTime date)
        {
            PlaygroundId = playgroundId;
            AppUserId = userId;
            PlayDate = DateTime.Now;
        }

        public int PlaygroundId { get; private set; }
        public Playground Playground { get; private set; }

        public int AppUserId { get; private set; }
        public AppUser AppUser { get; private set; }

        public DateTime PlayDate { get; private set; }
    }
}
