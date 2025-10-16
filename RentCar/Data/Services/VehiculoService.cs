using RentCar.Data.Context;
using RentCar.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace RentCar.Data.Services
{
    public class VehiculoService
    {
        private readonly ApplicationDbContext _context;

        public VehiculoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los vehículos
        public async Task<List<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos
                .Include(v => v.Categoria)
                .Include(v => v.TipoVehiculo)
                .ToListAsync();
        }

        // Obtener un vehículo por id
        public async Task<Vehiculo?> GetByIdAsync(int id)
        {
            return await _context.Vehiculos
                .Include(v => v.Categoria)
                .Include(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        // Crear un nuevo vehículo
        public async Task<Vehiculo> CreateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }

        // Actualizar un vehículo existente
        public async Task<bool> UpdateAsync(Vehiculo vehiculo)
        {
            var existing = await _context.Vehiculos.FindAsync(vehiculo.Id);
            if (existing == null) return false;

            existing.Marca = vehiculo.Marca;
            existing.Modelo = vehiculo.Modelo;
            existing.Año = vehiculo.Año;
            existing.Placa = vehiculo.Placa;
            existing.Color = vehiculo.Color;
            existing.TipoVehiculoId = vehiculo.TipoVehiculoId;
            existing.CategoriaId = vehiculo.CategoriaId;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar vehículo (lógico o físico según necesidad)
        public async Task<bool> DeleteAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return false;

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
