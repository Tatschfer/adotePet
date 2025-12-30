using System.Text.Json.Serialization;

namespace adotePet.Models
{
    public class Doador
    {
        public String nomeDoador { get; set; } = String.Empty;
        public String telefoneDoador { get; set; } = String.Empty;
        public String emailDoador { get; set; } = String.Empty;
        public int idDoador { get; set; }

        public Doador(String nomeDoador, String telefoneDoador, String emailDoador, int idDoador)
        {
            this.nomeDoador = nomeDoador;
            this.telefoneDoador = telefoneDoador;
            this.emailDoador = emailDoador;
            this.idDoador = idDoador;

        }
    }
}