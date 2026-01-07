using adotePet.Models;
using adotePet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace adotePet.Services
{
    public class DoadorService : IDoadorService
    {
        private readonly IDoadorRepository _repo;
        private readonly IPetRepository _petRepo;

        public DoadorService(IDoadorRepository _repo, IPetRepository _petRepo)
        {
            this._repo = _repo;
            this._petRepo = _petRepo;
        }

        public async Task<IEnumerable<Doador>> ObterDoadores()
        {
            var doadores = await _repo.GetAllAsync();
            return doadores;
        }

        public async Task<Doador> ObterDoadorById(int id)
        {
            var doador = await _repo.GetByIdAsync(id);
            return doador;
        }

        public async Task<Doador> CriarDoador(Doador doador)
        {
            var novoDoador = await _repo.InsertDoador(doador);
            return novoDoador;
        }

        public async Task<Doador> RemoverDoadorById(int idDoador)
        {
            var doador = await _repo.GetByIdAsync(idDoador);
            return doador;
        }

        public async Task<Doador> AtualizarDoador(Doador doador, int id)
        {
            doador.idDoador = id;

            var doadorExistente = await _repo.GetByIdAsync(id);
            if (doadorExistente == null)
                return null;
            var atualizado = await _repo.UpdateDoador(id, doador);
            if (!atualizado)
                return null;
            return doador;
        }

        public async Task<Pet> CriarDoacao(CriarDoacao criarDoacao)
        {
            var novoDoador = await _repo.InsertDoador(criarDoacao.Doador);
            criarDoacao.Pet.idDoador = novoDoador.idDoador;

            var novoPet = await _petRepo.InsertPet(criarDoacao.Pet);
            return novoPet;
        }
    }
}
