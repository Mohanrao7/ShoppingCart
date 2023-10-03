using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Model
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
