using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RentCar.Data.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string NombreCategoria { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public ICollection<Vehiculo>? Vehiculos { get; set; }
    }
}
