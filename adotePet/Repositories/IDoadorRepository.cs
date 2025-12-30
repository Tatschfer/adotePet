using adotePet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace adotePet.Repositories
{
    public interface IDoadorRepository
    {
        Task<IEnumerable<Doador>> GetAllAsync();
        Task<Doador?> GetByIdAsync(int idDoador);
        Task<Doador?> InsertDoador(Doador doador);
        Task<bool> DeleteDoador(int idDoador);
        Task<bool> UpdateDoador(Doador doador);
    }
}