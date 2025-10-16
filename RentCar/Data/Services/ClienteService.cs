using RentCar.Data.Context;
using RentCar.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace RentCar.Data.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(cliente.Id);
            if (existing == null) return false;

            existing.Nombre = cliente.Nombre;
            existing.Apellido = cliente.Apellido;
            existing.Email = cliente.Email;
            existing.Telefono = cliente.Telefono;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
