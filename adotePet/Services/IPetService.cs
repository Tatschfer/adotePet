using adotePet.Models;

namespace adotePet.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> ObterPets();

        Task<Pet> ObterPetById(int id);

        Task<Pet?> CriarPet(Pet pet);

        Task<Pet?> RemoverPetById(int id);

        Task<Pet?> AtualizarPet(int idPet, Pet pet);
    }
}
