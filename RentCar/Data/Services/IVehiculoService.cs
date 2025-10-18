using RentCar.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCar.Data.Services
{
    public interface IVehiculoService
    {
        Task<List<Vehiculo>> GetAllAsync();
        Task<Vehiculo?> GetByIdAsync(int id);
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(int id);
    }
}