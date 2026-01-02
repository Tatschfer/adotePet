using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace adotePet.Models

{
    public class Pet
    {
        public int idPet { get; set; }

        [Required(ErrorMessage = "O nome do pet é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 50 caracteres")]
        public String nome { get; set; } = string.Empty;

        [Range(0, 25, ErrorMessage = "A idade deve estar entre 0 e 25 anos")]
        public String idade { get; set; } = string.Empty;

        [Required(ErrorMessage = "A espécie do pet é obrigatória")]
        [EnumDataType(typeof(TipoPet), ErrorMessage = "Espécie de pet inválida")]
        public String especie { get; set; } = string.Empty;

        [Required(ErrorMessage = "A raça do pet é obrigatória")]
        public String raca { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cor do pet é obrigatória")]
        [EnumDataType(typeof(CorPet), ErrorMessage = "Cor de pet inválida")]
        public String cor { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro onde o pet se encontra é obrigatório")]
        public String bairro { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "A cidade onde o pet se encontra é obrigatória")]
        public String cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado onde o pet se encontra é obrigatório")]
        public String estado { get; set; } = string.Empty;
       
        [Required(ErrorMessage = "O país onde o pet se encontra é obrigatório")]
        public String pais { get; set; } = string.Empty;
        public int idDoador { get; set; }



        public Pet(int idPet, string nome, string raca, string cor, string especie, string idade, string bairro, string cidade, string estado, string pais, int idDoador)
        {
            this.idPet = idPet;
            this.nome = nome;
            this.idade = idade;
            this.especie = especie;
            this.raca = raca;
            this.cor = cor;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.pais = pais;
            this.idDoador = idDoador;
        }

    }

    public enum TipoPet
    {
        Cachorro = 1,
        Gato = 2,
        Ave = 3,
        Reptil = 4,
        Peixe = 5,
        Outro = 6
    }

    public enum CorPet
    {
        Branco = 1,
        Amarelo = 2,
        Frajola = 3,
        Cinza = 4,
        Rajado = 5,
        Preto = 6,
        Marrom = 7,
        Outro = 8
    }
}
