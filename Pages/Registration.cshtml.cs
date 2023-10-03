using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ShoppingCart.Model;
using ShoppingCart.Repositories;
using System.Data;

namespace ShoppingCart.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly IRepository IRepo ;
        public RegistrationModel(IRepository IRepo)
        {
            this.IRepo = IRepo ;
            
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public UserReg User { get; set; }

        public IActionResult OnPost([Bind("Username,Password,Gender,PhoneNumber,State")]  UserReg reg)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Here, you can add code to save the user registration data to a database
            // You can use Entity Framework or Dapper to interact with the database
            //var name=
            IRepo.Add(reg);
            
            //User.Username=name.ToString();

            // Redirect to a confirmation page or login page
            return RedirectToPage("Login");

        }
    }
}
