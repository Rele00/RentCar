using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Apellido { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Documento { get; set; } = string.Empty;

        [Required, MaxLength(13)]
        public string? Cedula { get; set; } // Cédula

        [Required, MaxLength(50)]
        public string? Licencia { get; set; }

        [Required, MaxLength(10)]
        public string? Telefono { get; set; }

        [Required, MaxLength(100)]
        public string? Email { get; set; }

        public bool EsActivo { get; set; } = true;
    }
}
