namespace adotePet.Models
{
    public class CriarDoacao
    {
        public Doador Doador { get; set; }
        public Pet Pet { get; set; }

        public CriarDoacao(Doador doador, Pet pet)
        {
            Doador = doador;
            Pet = pet;
        }

    }
}
