using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PURE.DTOs
{
    public class CadastroEventoDTO
    {
        [Required]
        public string EventName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string EventLocal { get; set; }

        [Required]
        public string EventDate { get; set; }

        [Required]
        public string InitialEventTime { get; set; }

        [Required]
        public float EventPoint { get; set; }
    }
}
