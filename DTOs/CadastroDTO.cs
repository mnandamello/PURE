using System.ComponentModel.DataAnnotations;

namespace PURE.DTOs
{
    public class CadastroDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
