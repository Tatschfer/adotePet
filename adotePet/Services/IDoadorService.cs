using adotePet.Models;

namespace adotePet.Services
{
    public interface IDoadorService
    {
        Task<IEnumerable<Doador>> ObterDoadores();

        Task<Doador> ObterDoadorById(int id);

        Task<Doador> CriarDoador(Doador doador);
        Task<bool> RemoverDoadorById(int idDoador);

        Task<Doador> AtualizarDoador(Doador doador, int id);

        Task<Pet> CriarDoacao(CriarDoacao criarDoacao);
    }
}
