using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PURE.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
