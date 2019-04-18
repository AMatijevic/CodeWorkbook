using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLogin_RazorPages.DomainModel.Entities;

namespace UserLogin_RazorPages.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } 

        public void OnGet(string returnUrl = null)
        {
            Input = new InputModel();
            Input.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            const string badUserNameOrPasswordMessage = "Username or password is incorrect.";

            if (string.IsNullOrEmpty(Input.Username)|| string.IsNullOrEmpty(Input.Password))
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            var lookupUser = DataAccess.Data.Users.FirstOrDefault(u => u.Username.Equals(Input.Username));

            if (lookupUser?.Password != Input.Password)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            const string Issuer = "https://gov.uk";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Input.Username, ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Surname, "Matijevic", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Country, "CRO", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Email, "andrej.matijevic@gmail.com", ClaimValueTypes.String, Issuer),
                new Claim("ChildhoodHero", "Michael Jordan", ClaimValueTypes.String)
            };
            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(userPrincipal));

            if (Input.ReturnUrl == null)
            {
                Input.ReturnUrl = TempData["returnUrl"]?.ToString();
            }

            if (Input.ReturnUrl != null)
            {
                return Redirect(Input.ReturnUrl);
            }

            return RedirectToPage("/Index");

        }

        public class InputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string ReturnUrl { get; set; }
        }
    }
}