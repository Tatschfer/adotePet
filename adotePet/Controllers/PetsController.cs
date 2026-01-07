using adotePet.Models;
using adotePet.Repositories;
using adotePet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace adotePet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        private readonly IPetService _petService;
        public PetsController(IPetService _petService)
        {
            this._petService = _petService;
        }


        [HttpGet]
        public async Task<IActionResult> ObterPets()
        {
            var pets = _petService.ObterPets();
            return Ok(pets);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPetById(int id)
        {
            var pet = _petService.ObterPetById(id);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

   

        [HttpPost]
        public async Task<IActionResult> CriarPet([FromBody] Pet pet)
        {
            var novoPet = _petService.CriarPet(pet);
            if (novoPet == null)
                return BadRequest("Não foi possível criar o pet.");
            return CreatedAtAction(nameof(ObterPetById), new { id = novoPet.idPet }, novoPet);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverPetById(int id)
        {
            var petRemovido = await _petService.RemoverPetById(id);
            if (petRemovido == null)
            {
                return NotFound("Pet não encontrado");
            }
            return Ok(new { mensagem = "Pet removido com sucesso", pet = petRemovido });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPet(
            
            [FromBody] Pet pet, 
            [FromRoute] int id)
        {

            pet.idPet = id;

            var petExistente = await _petService.AtualizarPet(id, pet);
            if (petExistente == null)
                return NotFound();
            var atualizado = await _petService.AtualizarPet(id, pet);
            if (atualizado == null)
                return BadRequest("Não foi possível atualizar o pet.");
            return Ok("Pet atualizado com sucesso.");
        }
    }
}
