namespace IvSite.Web.Models.AccountViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static IvSite.Data.DataConstants;

    public class RegisterViewModel
    {
        [Required]
        [DisplayName("First Name")]
        [MinLength(MinLenghtName,ErrorMessage ="The Name must be at least 2 symbols in lenght")]
        [MaxLength(MaxLenghtName,ErrorMessage = "The Name must be no more than 100 symbols in length")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MinLength(MinLenghtName, ErrorMessage = "The Name must be at least 2 symbols in lenght")]
        [MaxLength(MaxLenghtName, ErrorMessage = "The Name must be no more than 100 symbols in length")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [MinLength(MinLenPhone,ErrorMessage = @"The Phone must start with ""+"" and must be at least 8 characters in length")]
        [MaxLength(MaxLenPhone,ErrorMessage = "Phone number must be no more than 15 characters in length")]
        public string Phone { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
