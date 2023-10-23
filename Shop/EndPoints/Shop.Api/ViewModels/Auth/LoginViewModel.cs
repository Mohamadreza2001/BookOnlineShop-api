using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter the phone number")]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; } = string.Empty;
    }
}
