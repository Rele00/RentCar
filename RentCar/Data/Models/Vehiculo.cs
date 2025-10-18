using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentCar.Data.Models

{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int Año { get; set; }

        [Required, MaxLength(15)]
        public string Placa { get; set; } = string.Empty;

        [MaxLength(30)]
        public string Color { get; set; } = string.Empty;

        public int TipoVehiculoId { get; set; }
        [ForeignKey(nameof(TipoVehiculoId))]
        public TipoVehiculo? TipoVehiculo { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public Categoria? Categoria { get; set; }

        [Required]
        public string Estado { get; set; } = "Disponible";

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool EsActivo { get; set; } = true;
    }
}
