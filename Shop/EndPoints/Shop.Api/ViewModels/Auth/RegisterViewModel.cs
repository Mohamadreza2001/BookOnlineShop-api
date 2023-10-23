using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter the phone number")]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the password")]
        [MinLength(6, ErrorMessage = "Password should be more than 5 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the confirm password")]
        [MinLength(6, ErrorMessage = "Confirm password should be more than 5 characters")]
        [Compare(nameof(Password), ErrorMessage = "Password and its repeat are not same")]
        public string ConfirmedPassword { get; set; } = string.Empty;
    }
}
