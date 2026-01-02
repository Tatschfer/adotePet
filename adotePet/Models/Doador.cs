using System.Text.Json.Serialization;

namespace adotePet.Models
{
    public class Doador
    {
        public String nome { get; set; } = String.Empty;
        public String telefone { get; set; } = String.Empty;
        public String email { get; set; } = String.Empty;
        public int idDoador { get; set; }

        public Doador(int idDoador, String nome, String telefone, String email)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.idDoador = idDoador;

        }
    }
}