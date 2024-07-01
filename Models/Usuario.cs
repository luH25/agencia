using S.I_AgenciaViajes.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S.I_AgenciaViajes.Models
{
    public class Usuario
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int Celular { get; set; }
        [Required]
        public string? Email {  get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public CargoEnum Cargo { get; set; }
        public bool Estado { get; set; }
    }
}
