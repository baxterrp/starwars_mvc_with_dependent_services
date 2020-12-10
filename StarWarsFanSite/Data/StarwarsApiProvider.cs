using Newtonsoft.Json;
using StarWarsFanSite.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsFanSite.Data
{
    public class StarwarsApiProvider : IStarWarsApiProvider
    {
        private static readonly string _baseUrl = "https://swapi.dev/api";

        public async Task<List<FilmResponse>> GetAllFilms()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/films/");

            HttpResponseMessage response = await client.SendAsync(request);
            string stringResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FilmApiResponse>(stringResponse).Films.ToList();
        }

        public async Task<CharacterApiResponse> GetCharacter(string characterId)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/people/{characterId}/");

            HttpResponseMessage response = await client.SendAsync(request);
            string stringResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterApiResponse>(stringResponse);
        }
    }
}
