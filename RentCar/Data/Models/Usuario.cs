using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [EmailAddress,MaxLength(100)]
        public string? Email { get; set; }

        [Required, MaxLength(30)]
        public string? Telefono { get; set; }

        [Required, MaxLength(50)]
        public string? Rol { get; set; } // Admin, Recepción, etc.

        public bool EsActivo { get; set; } = true;
    }
}
