using RentCar.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCar.Data.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}