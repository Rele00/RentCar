using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentCar.Data.Models;

namespace RentCar.Data.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Vehiculo> Vehiculos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<TipoVehiculo> TiposVehiculos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*Es obligatoria, ya que el contexto hereda de IdentityDbContext y esa llamada crea todas las tablas del sistema de Identity.
            Sin ella, las tablas de usuarios (AspNetUsers, etc.) no se generar�an.*/

            // Configuraci�n de relaciones o restricciones adicionales

            /*Traducci�n a lenguaje natural:
            Un veh�culo pertenece a una categor�a.

            Una categor�a puede tener muchos veh�culos.

            La clave for�nea es CategoriaId.

            Y si se elimina una categor�a, EF Core restringe la eliminaci�n (Restrict) en lugar de borrar los veh�culos relacionados (evita borrados en cascada).*/
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Categoria)
                .WithMany(c => c.Vehiculos)
                .HasForeignKey(v => v.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.TipoVehiculo)
                .WithMany(t => t.Vehiculos)
                .HasForeignKey(v => v.TipoVehiculoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
