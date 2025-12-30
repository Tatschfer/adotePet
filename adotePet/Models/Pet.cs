using System.Text.Json.Serialization;

namespace adotePet.Models

{
    public class Pet
    {
        public int idPet { get; set; }
        public String nomePet { get; set; } = string.Empty;
        public String idadePet { get; set; } = string.Empty;
        public String especiePet { get; set; } = string.Empty;
        public String racaPet { get; set; } = string.Empty;
        public String corPet { get; set; } = string.Empty;

        public Pet(int idPet, string nomePet, string racaPet, string corPet, string especiePet, string idadePet)
        {
            this.idPet = idPet;
            this.nomePet = nomePet;
            this.idadePet = idadePet;
            this.especiePet = especiePet;
            this.racaPet = racaPet;
            this.corPet = corPet;
        }

    }
}
