using System.ComponentModel.DataAnnotations;

namespace SchoolActivation.ViewModels
{
	public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
