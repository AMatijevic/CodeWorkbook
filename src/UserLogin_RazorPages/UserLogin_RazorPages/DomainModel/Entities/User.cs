using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLogin_RazorPages.DomainModel.Entities
{
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
