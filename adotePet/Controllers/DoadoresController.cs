using adotePet.Models;
using adotePet.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace adotePet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadoresController : ControllerBase
    {
        private readonly IDoadorRepository _repo;
        public DoadoresController(IDoadorRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> ObterDoadores()
        {
            var doadores = await _repo.GetAllAsync();
            return Ok(doadores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDoadorById(int id)
        {
            var doador = await _repo.GetByIdAsync(id);
            if (doador == null)
                return NotFound();
            return Ok(doador);
        }

        [HttpPost]
        public async Task<IActionResult> CriarDoador([FromBody] Models.Doador doador)
        {
            var novoDoador = await _repo.InsertDoador(doador);
            if (novoDoador == null)
                return BadRequest("Não foi possível cadastrar o doador.");
            return CreatedAtAction(nameof(ObterDoadorById), new { id = novoDoador.idDoador }, novoDoador);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverDoadorById(int idDoador)
        {
            var doador = await _repo.GetByIdAsync(idDoador);
            if (doador == null)
                return NotFound();
            await _repo.DeleteDoador(idDoador);
            return Ok("Doador removido com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDoador(
            
            [FromBody] Models.Doador doador, 
            [FromRoute] int id)
        {
            doador.idDoador = id;

            var doadorExistente = await _repo.GetByIdAsync(id);
            if (doadorExistente == null)
                return NotFound();
            var atualizado = await _repo.UpdateDoador(id, doador);
            if (!atualizado)
                return BadRequest("Não foi possível atualizar o doador.");
            return Ok("Doador atualizado com sucesso.");
        }
    }
}
