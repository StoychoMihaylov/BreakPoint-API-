namespace BreakPoint.Models.BindingModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterBindingModel
    {
        [MaxLength(50)]
        public string Nickname { get; set; }

        public string Location { get; set; }

        public string DancerType { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
