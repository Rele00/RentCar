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
            Sin ella, las tablas de usuarios (AspNetUsers, etc.) no se generarían.*/

            // Configuración de relaciones o restricciones adicionales

            /*Traducción a lenguaje natural:
            Un vehículo pertenece a una categoría.

            Una categoría puede tener muchos vehículos.

            La clave foránea es CategoriaId.

            Y si se elimina una categoría, EF Core restringe la eliminación (Restrict) en lugar de borrar los vehículos relacionados (evita borrados en cascada).*/
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
