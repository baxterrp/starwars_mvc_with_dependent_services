using StarWarsFanSite.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsFanSite.Data
{
    public interface IStarWarsApiProvider
    {
        Task<CharacterApiResponse> GetCharacter(string characterId);
        Task<List<FilmResponse>> GetAllFilms();
    }
}
