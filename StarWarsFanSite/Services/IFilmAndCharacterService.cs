using StarWarsFanSite.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsFanSite.Services
{
    public interface IFilmAndCharacterService
    {
        Task SaveFavoriteCharacter(Character character);
        Task<List<Film>> GetAllFilms();
    }
}
