using System.ComponentModel.DataAnnotations;

namespace CanteenManagement.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage ="Confirm password is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        public string PhoneNumber { get; set; } 
    }
    public class AddUser
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
    }

    public class EditUser
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        //public string? Role { get; set; }
    }
}
