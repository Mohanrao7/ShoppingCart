using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Model;
using ShoppingCart.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Pages
{
    public class LoginModel : PageModel
    {
        //[BindProperty]
        //[Required(ErrorMessage = "Username is required.")]
        //public string Username { get; set; }

        //[BindProperty]
        //[Required(ErrorMessage = "Password is required.")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
        private readonly IRepository IRepo;
        public LoginModel(IRepository IRepo)
        {
            this.IRepo= IRepo;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public UserLogin UserL { get; set; }
        public IActionResult OnPost([Bind("Username,Password")] UserLogin UserL)
        {
            if (ModelState.IsValid)
            {

                List<UserLogin> userLogins = IRepo.GetFeilds();
                
                if (userLogins.Any(u => u.Username == UserL.Username) && userLogins.Any(u => u.Password==UserL.Password))
                {
                    
                    TempData["Message"] = "Login successful!";
                    return RedirectToPage("/Index"); 
                }
                else
                {
                    
                    TempData["Message"] = "Username not found. Please register.";
                    return RedirectToPage(); 
                }
            }
            
            
            return Page();
        }
    }
}
