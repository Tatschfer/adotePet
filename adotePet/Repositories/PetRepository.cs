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
                    nomePet, 
                    racaPet, 
                    corPet, 
                    especiePet, 
                    idadePet 
                FROM pets;";

            return await _db.QueryAsync<Pet>(sql);
        }

        public async Task<Pet?> GetByIdAsync(int idPet)
        {
            const string sql = @"
                SELECT 
                    idPet, 
                    nomePet, 
                    racaPet, 
                    corPet, 
                    especiePet, 
                    idadePet 
                FROM pets 
                WHERE idPet = @Id;";

            return await _db.QueryFirstOrDefaultAsync<Pet>(sql, new { Id = idPet });
        }

        public async Task<Pet?> InsertPet(Pet pet)
        {
            const string sql = @"
                INSERT INTO pets (nomePet, racaPet, corPet, especiePet, idadePet) 
                VALUES (@nomePet, @racaPet, @corPet, @especiePet, @idadePet);
                SELECT LAST_INSERT_ID();";
            var id = await _db.QuerySingleAsync<int>(sql, new
            {
                NomePet = pet.nomePet,
                RacaPet = pet.racaPet,
                CorPet = pet.corPet,
                EspeciePet = pet.especiePet,
                IdadePet = pet.idadePet
            });

            pet.idPet = id;
            return pet;
        }

        public async Task<bool> DeletePet(int idPet)
        {
            const string sql = @"
                DELETE FROM pets 
                WHERE idPet = @id;";
            var rowsAffected = await _db.ExecuteAsync(sql, new { Id = idPet });
            return rowsAffected > 0;
        }

        public async Task<bool> UpdatePet(int id, Pet pet)
        {
            const string sql = @"
                UPDATE pets 
                SET nomePet = @nomePet, 
                    racaPet = @racaPet, 
                    corPet = @corPet, 
                    especiePet = @especiePet, 
                    idadePet = @idadePet 
                WHERE idPet = @idPet;";
            var rowsAffected = await _db.ExecuteAsync(sql, new
            {
                IdPet = pet.idPet,
                NomePet = pet.nomePet,
                RacaPet = pet.racaPet,
                CorPet = pet.corPet,
                EspeciePet = pet.especiePet,
                IdadePet = pet.idadePet
            });
            return rowsAffected > 0;
        }
    }
}