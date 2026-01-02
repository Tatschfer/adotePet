using System.Text.Json.Serialization;

namespace adotePet.Models

{
    public class Pet
    {
        public int idPet { get; set; }
        public String nome { get; set; } = string.Empty;
        public String idade { get; set; } = string.Empty;
        public String especie { get; set; } = string.Empty;
        public String raca { get; set; } = string.Empty;
        public String cor { get; set; } = string.Empty;
        public String bairro { get; set; } = string.Empty;
        public String cidade { get; set; } = string.Empty;
        public String estado { get; set; } = string.Empty;
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
}
