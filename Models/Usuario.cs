using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PURE.Models
{
    [Table("T_USUARIO")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome_Usuario")]
        public string UserName { get; set; }

        [Required]
        [Column("Email_Usuario")]
        public string UserEmail { get; set; }

        [Required]
        [Column("Hash_Senha")]
        public string PasswordHash { get; set; }

        [Required]
        [Column("Usuario_Ativo")]
        public bool isActive { get; set; } = true;

        public ICollection<Evento>? Eventos { get; set; }
    }
}
