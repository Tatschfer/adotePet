using System.Data;
using adotePet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dapper;

namespace adotePet.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly IDbConnection _db;
        public DoadorRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Doador>> GetAllAsync()
        {
            const string sql = @"
                SELECT 
                    idDoador,
                    nome,
                    telefone,
                    email
                FROM doadores;";

            return await _db.QueryAsync<Doador>(sql);
        }

        public async Task<Doador?> GetByIdAsync(int idDoador)
        {
            const string sql = @"
                SELECT 
                    idDoador,
                    nome,
                    telefone,
                    email
                FROM doadores 
                WHERE idDoador = @Id;";
            return await _db.QueryFirstOrDefaultAsync<Doador>(sql, new { Id = idDoador });
        }

        public async Task<Doador?> InsertDoador(Doador doador)
        {
            const string sql = @"
                INSERT INTO doadores (nome, telefone, email) 
                VALUES (@nome, @telefone, @email);
                SELECT LAST_INSERT_ID();";
            var id = await _db.QuerySingleAsync<int>(sql, new
            {
                Nome = doador.nome,
                Telefone = doador.telefone,
                Email = doador.email
            });

            doador.idDoador = id;
            return doador;
        }

        public async Task<bool> DeleteDoador(int id)
        {
            const string sql = @"
                DELETE FROM doadores 
                WHERE idDoador = @Id;";
            var rowsAffected = await _db.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateDoador(int id, Doador doador)
        {
            const string sql = @"
                UPDATE doadores 
                SET nome = @nome, 
                    telefone = @telefone, 
                    email = @email
                WHERE IdDoador = @idDoador;";
            var rowsAffected = await _db.ExecuteAsync(sql, new
            {
                Nome = doador.nome,
                Telefone = doador.telefone,
                Email = doador.email,
                IdDoador = doador.idDoador
            });
            return rowsAffected > 0;
        }
    }

 }