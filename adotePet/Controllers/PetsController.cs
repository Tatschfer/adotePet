using adotePet.Models;
using adotePet.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace adotePet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _repo;
        public PetsController(IPetRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> ObterPets()
        {
            var pets = await _repo.GetAllAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPetById(int id)
        {
            var pet = await _repo.GetByIdAsync(id);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPet([FromBody] Models.Pet pet)
        {
            var novoPet = await _repo.InsertPet(pet);
            if (novoPet == null)
                return BadRequest("Não foi possível criar o pet.");
            return CreatedAtAction(nameof(ObterPetById), new { id = novoPet.idPet }, novoPet);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverPetById(int id)
        {
            var pet = await _repo.GetByIdAsync(id);
            if (pet == null)
                return NotFound();
            await _repo.DeletePet(id);
            return Ok("Pet removido com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPet(
            
            [FromBody] Models.Pet pet, 
            [FromRoute] int id)
        {

            pet.idPet = id;

            var petExistente = await _repo.GetByIdAsync(id);
            if (petExistente == null)
                return NotFound();
            var atualizado = await _repo.UpdatePet(id, pet);
            if (!atualizado)
                return BadRequest("Não foi possível atualizar o pet.");
            return Ok("Pet atualizado com sucesso.");
        }
    }
}
