using Microsoft.AspNetCore.Mvc;
using adotePet.Repositories;
using adotePet.Models;

namespace adotePet.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;

        public PetService(IPetRepository _repo)
        {
            this._repo = _repo;
        }

        public async Task<IEnumerable<Pet>> ObterPets()
        {
            var pets = await _repo.GetAllAsync();
            return pets;
        }

        public async Task<Pet> ObterPetById(int id)
        {
            var pet = await _repo.GetByIdAsync(id);
            return pet;
        }
        public async Task<Pet?> CriarPet(Pet pet)
        {
            var novoPet = await _repo.InsertPet(pet);
            return novoPet;
        }

        public async Task<Pet?> RemoverPetById(int id)
        {
            var pet = await _repo.GetByIdAsync(id);

            if (pet == null)
                return null;

            await _repo.DeletePet(id);
            return pet;
        }

        public async Task<Pet?> AtualizarPet(int id, Pet pet)
        {
            pet.idPet = id;

            var petExistente = await _repo.GetByIdAsync(id);
            if (petExistente == null)
                return null;
            var atualizado = await _repo.UpdatePet(id, pet);
            if (!atualizado)
                return null;
            return pet;
        }
    }
};
