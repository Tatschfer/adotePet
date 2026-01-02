using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace adotePet.Models
{
    public class Doador
    {
        [Required(ErrorMessage = "O nome completo é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 50 caracteres")]
        public String nome { get; set; } = String.Empty;

        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        public String telefone { get; set; } = String.Empty;
        
        [EmailAddress]
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