using System.Data;
using adotePet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dapper;

namespace adotePet.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IDbConnection _db;
        public PetRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            const string sql = @"
                SELECT 
                    idPet, 
                    nome, 
                    raca, 
                    cor, 
                    especie, 
                    dataDeNascimento,
                    bairro,
                    cidade,
                    estado,
                    pais,
                    idDoador
                FROM pets;";

            return await _db.QueryAsync<Pet>(sql);
        }

        public async Task<Pet?> GetByIdAsync(int idPet)
        {
            const string sql = @"
                SELECT 
                    idPet, 
                    nome, 
                    raca, 
                    cor, 
                    especie, 
                    dataDeNascimento,
                    bairro,
                    cidade,
                    estado,
                    pais,
                    idDoador
                FROM pets 
                WHERE idPet = @Id;";

            return await _db.QueryFirstOrDefaultAsync<Pet>(sql, new { Id = idPet });
        }

        public async Task<Pet?> InsertPet(Pet pet)
        {
            const string sql = @"
                INSERT INTO pets (nome, raca, cor, especie, dataDeNascimento, bairro, cidade, estado, pais, idDoador) 
                VALUES (@nome, @raca, @cor, @especie, @dataDeNascimento, @bairro, @cidade, @estado, @pais, @idDoador);
                SELECT LAST_INSERT_ID();";
            var id = await _db.QuerySingleAsync<int>(sql, new
            {
                Nome = pet.nome,
                Raca = pet.raca,
                Cor = pet.cor,
                Especie = pet.especie,
                DataDeNascimento = pet.dataDeNascimento,
                Bairro = pet.bairro,
                Cidade = pet.cidade,
                Estado = pet.estado,
                Pais = pet.pais,
                IdDoador = pet.idDoador
            });

            pet.idPet = id;
            return pet;
        }

        public async Task<bool> DeletePet(int id)
        {
            const string sql = @"
                DELETE FROM pets 
                WHERE idPet = @Id;";
            var rowsAffected = await _db.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<bool> UpdatePet(int id, Pet pet)
        {
            const string sql = @"
                UPDATE pets 
                SET nome = @nome, 
                    raca = @raca, 
                    cor = @cor, 
                    especie = @especie, 
                    dataDeNascimento = @dataDeNascimento,
                    bairro = @bairro,
                    cidade = @cidade,
                    estado = @estado,
                    pais = @pais,
                    idDoador = @idDoador
                WHERE idPet = @idPet;";
            var rowsAffected = await _db.ExecuteAsync(sql, new
            {
                IdPet = pet.idPet,
                Nome = pet.nome,
                Raca = pet.raca,
                Cor = pet.cor,
                Especie = pet.especie,
                DataDeNascimento = pet.dataDeNascimento,
                Bairro = pet.bairro,
                Cidade = pet.cidade,
                Estado = pet.estado,
                Pais = pet.pais,
                IdDoador = pet.idDoador
            });
            return rowsAffected > 0;
        }
    }
}