using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(40)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        [Compare(nameof(Password))]
        public string ConfirmPasseord { get; set; }
    }
}
