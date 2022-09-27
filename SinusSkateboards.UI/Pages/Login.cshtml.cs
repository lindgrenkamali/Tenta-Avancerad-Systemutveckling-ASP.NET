using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages
{

    [BindProperties]

    public class LoginModel : PageModel
    {
        private readonly SignInManager<AdminModel> signInManager;

        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        public string Password { get; set; }

        public LoginModel(SignInManager<AdminModel> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //Kollar om både Username och Password är i fyllt
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Username, Password, false, false);

                if(result.Succeeded)
                {
                    return RedirectToPage("/Admin/Index");
                }
            }
            return Page();
        }
    }
}
