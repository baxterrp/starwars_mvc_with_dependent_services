using Dapper;
using Microsoft.Data.SqlClient;
using StarWarsFanSite.Entities;
using System.Threading.Tasks;

namespace StarWarsFanSite.Data
{
    public class CharacterRepository : ICharacterRepository
    {
        private static readonly string _connectionString = "Server=Silver;Database=starwars;Trusted_Connection=True;MultipleActiveResultSets=true";

        public async Task<Character> GetCharacter(string characterId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleAsync<Character>($"SELECT * FROM FavoriteCharacter WHERE apiId = @ApiId", new { ApiId = characterId });
        }

        public async Task SaveCharacter(Character character)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"INSERT INTO FavoriteCharacter (name, apiId) VALUES (@Name, @ApiId)", character);
        }
    }
}
