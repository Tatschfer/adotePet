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
                    nomeDoador,
                    telefoneDoador,
                    emailDoador
                FROM doadores;";

            return await _db.QueryAsync<Doador>(sql);
        }

        public async Task<Doador?> GetByIdAsync(int idDoador)
        {
            const string sql = @"
                SELECT 
                    idDoador,
                    nomeDoador,
                    telefoneDoador,
                    emailDoador
                FROM doadores 
                WHERE idDoador = @Id;";
            return await _db.QueryFirstOrDefaultAsync<Doador>(sql, new { Id = idDoador });
        }

        public async Task<Doador?> InsertDoador(Doador doador)
        {
            const string sql = @"
                INSERT INTO doadores (nomeDoador, telefoneDoador, emailDoador) 
                VALUES (@nomeDoador, @telefoneDoador, @emailDoador);
                SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await _db.QuerySingleAsync<int>(sql, new
            {
                NomeDoador = doador.nomeDoador,
                TelefoneDoador = doador.telefoneDoador,
                EmailDoador = doador.emailDoador
            });

            doador.idDoador = id;
            return doador;
        }

        public async Task<bool> DeleteDoador(int idDoador)
        {
            const string sql = @"
                DELETE FROM doadores 
                WHERE idDoador = @Id;";
            var rowsAffected = await _db.ExecuteAsync(sql, new { Id = idDoador });
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateDoador(Doador doador)
        {
            const string sql = @"
                UPDATE doadores 
                SET nomeDoador = @nomeDoador, 
                    telefoneDoador = @telefoneDoador, 
                    emailDoador = @emailDoador
                WHERE idDoador = @idDoador;";
            var rowsAffected = await _db.ExecuteAsync(sql, new
            {
                NomeDoador = doador.nomeDoador,
                TelefoneDoador = doador.telefoneDoador,
                EmailDoador = doador.emailDoador,
                IdDoador = doador.idDoador
            });
            return rowsAffected > 0;
        }
    }

 }