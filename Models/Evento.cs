using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PURE.Models
{
    [Table("T_EVENTO")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }

        [Required]
        [Column("Nome_Eventp")]
        public string EventName { get; set; }

        [Required]
        [Column("Descricao")]
        public string Description { get; set; }

        [Required]
        [Column("Local_Evento")]
        public string EventLocal { get; set;}

        [Required]
        [Column("Data_Evento")]
        public string EventDate { get; set; }

        [Required]
        [Column("Hora_Inicial_do_Evento")]
        public string InitialEventTime { get; set; }

        [Required]
        [Column("Pontos_Evento")]
        public float EventPoint { get; set; }

    }
}
