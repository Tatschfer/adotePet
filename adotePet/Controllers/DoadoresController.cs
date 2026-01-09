using adotePet.Models;
using adotePet.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using adotePet.Services;

namespace adotePet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadoresController : ControllerBase
    {
        private readonly IDoadorService _doadorService;
        public DoadoresController(IDoadorService _doadorService)
        {
            this._doadorService = _doadorService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterDoadores()
        {
            var doadores = await _doadorService.ObterDoadores();
            return Ok(doadores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDoadorById(int id)
        {
            var doador = await _doadorService.ObterDoadorById(id);
            if (doador == null)
                return NotFound();
            return Ok(doador);
        }

        [HttpPost("criarDoador")]
        public async Task<IActionResult> CriarDoador(Doador doador)
        {
            var novoDoador = await _doadorService.CriarDoador(doador); 
            if (novoDoador == null)
                return BadRequest("Não foi possível cadastrar o doador.");
            return CreatedAtAction(nameof(ObterDoadorById), new { id = novoDoador.idDoador }, novoDoador);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverDoadorById(int idDoador)
        {
            var doador = await _doadorService.ObterDoadorById(idDoador);
            if (doador == null)
                return NotFound();
            await _doadorService.RemoverDoadorById(idDoador);
            return Ok("Doador removido com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDoador(
            
            [FromBody] Models.Doador doador, 
            [FromRoute] int id)
        {
            doador.idDoador = id;

            var doadorExistente = await _doadorService.AtualizarDoador(doador, id);
            if (doadorExistente == null)
                return NotFound();
            var atualizado = await _doadorService.AtualizarDoador(doador, id);
            if (atualizado == null)
                return BadRequest("Não foi possível atualizar o doador.");
            return Ok("Doador atualizado com sucesso.");
        }

        [HttpPost("criarDoacao")]
        public async Task<IActionResult> CriarDoacao(CriarDoacao criarDoacao)
        {
            var novaDoacao = await _doadorService.CriarDoacao(criarDoacao);
            if (novaDoacao == null)
                return BadRequest("Não foi possível realizar o cadastro.");
            return Ok("Doador e pet cadastrados com sucesso.");
        }
    }
}
