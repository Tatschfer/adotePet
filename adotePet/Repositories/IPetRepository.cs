using adotePet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace adotePet.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet?> GetByIdAsync(int idPet);
        Task<Pet?> InsertPet(Pet pet);

        Task<bool> UpdatePet(int  idPet, Pet pet);

        Task<bool> DeletePet(int idPet);    
    }
}