using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.DataAccess
{
    public static class Db
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User { Username = "Marko@gmail.com", Password = "Pass" },
            new User { Username = "Ivan@gmail.com", Password = "IvanPass!" },
            new User { Username = "Sanja@gmail.com", Password = "SanjaPassword2!" }
        };
    }
}
