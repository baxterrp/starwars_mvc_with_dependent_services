using StarWarsFanSite.Data;
using StarWarsFanSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsFanSite.Services
{
    public class FilmAndCharacterService : IFilmAndCharacterService
    {
        private readonly IStarWarsApiProvider _starWarsApiProvider;
        private readonly ICharacterRepository _starwarsRepository;
        private static DateTime _timeStamp = DateTime.Now;
        private static List<Film> _cachedFilms = new List<Film>();

        public FilmAndCharacterService(IStarWarsApiProvider starWarsApiProvider, ICharacterRepository starwarsRepository)
        {
            _starWarsApiProvider = starWarsApiProvider;
            _starwarsRepository = starwarsRepository;
        }

        public async Task<List<Film>> GetAllFilms()
        {
            if(_cachedFilms.Any() && DateTime.Now - _timeStamp < TimeSpan.FromMinutes(10))
            {
                return _cachedFilms;
            }

            var filmList = await _starWarsApiProvider.GetAllFilms();

            List<Task<Film>> films = filmList.Select(f => CreateFilmFromApiResponse(f)).ToList();

            var result = (await Task.WhenAll(films)).ToList();

            _cachedFilms = result;
            _timeStamp = DateTime.Now;

            return result;
        }

        public async Task SaveFavoriteCharacter(Character character)
        {
            await _starwarsRepository.SaveCharacter(character);
        }

        private async Task<Film> CreateFilmFromApiResponse(FilmResponse filmApiResponse) =>
            new Film
            {
                Title = filmApiResponse.Title,
                Director = filmApiResponse.Director,
                ReleaseDate = filmApiResponse.ReleaseDate,
                Episode = filmApiResponse.EpisodeId,
                Characters = (await GetCharacters(filmApiResponse)).ToList()
            };

        private async Task<List<CharacterApiResponse>> GetCharacters(FilmResponse film)
        {
            IEnumerable<Task<CharacterApiResponse>> tasks = 
                film.Characters.Select(c => _starWarsApiProvider.GetCharacter(c.Split("/").Last(id => !string.IsNullOrWhiteSpace(id))));

            return (await Task.WhenAll(tasks)).ToList();
        }
    }
}
