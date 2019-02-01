namespace BreakPoint.Models.BindingModels.Profile
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileBindingModel
    {
        public byte[] Avatar { get; set; }

        [Required]
        [MaxLength(50)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        public string Location { get; set; }

        public string PreName { get; set; }

        [Required(ErrorMessage = "Style is required!")]
        public string Style { get; set; }

        [Required(ErrorMessage = "Gernder is required!")]
        public string Gernder { get; set; }

        public string Biography { get; set; }
    }
}
