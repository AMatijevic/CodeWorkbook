using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogin_RazorPages.DomainModel.Entities;

namespace UserLogin_RazorPages.DataAccess
{
    public static class Data
    {
        public static List<Playground> Playgrounds = new List<Playground>
        {
            new Playground{ Id=1, Name="Trsat Vojno", StartTime = "18:30", Users = new List<User>()},
            new Playground{ Id=2, Name="Zamet", StartTime = "17:00", Users = new List<User>()},
            new Playground{ Id=3, Name="Kostrena", StartTime = string.Empty, Users = new List<User>()},
        };

        public static List<User> Users = new List<User>
        {
            new User{ Email="andrej.matijevic@gmail.com", Username="AMatijevic", Password="Passw0rd!", ImageUrl=string.Empty}
        };

    }
}
