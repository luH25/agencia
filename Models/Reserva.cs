using S.I_AgenciaViajes.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S.I_AgenciaViajes.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? NombreTurista { get; set; }
        [Required]
        public int CantidadTuristas { get; set; }
        public int NroReserva { get; set; }
        [Required]
        public string? Destino { get; set; }
        [Required]
        public decimal CostoTotal { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public EstadoViaje EstadoViaje { get; set; }

        //atributs computados
        

        public string? ComprobantePago { get; set; }
        [NotMapped]
        [Display(Name = "Cargar Comprobante")]
        public IFormFile? ImageFile { get; set; }


    }
}
