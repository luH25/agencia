using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S.I_AgenciaViajes.Models
{
    public class PaqueteTuristico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Destino { get; set; }
        [Required]
        public string? Tipo { get; set; }
        [Required]
        public decimal CostoUnit { get; set;}

    }
}
