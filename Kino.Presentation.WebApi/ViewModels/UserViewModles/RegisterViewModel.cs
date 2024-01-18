using System.ComponentModel.DataAnnotations;

namespace Kino.Presentation.WebApi.ViewModels.UserViewModles
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}