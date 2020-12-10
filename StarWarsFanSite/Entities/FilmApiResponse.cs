using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsFanSite.Entities
{
    public class FilmApiResponse
    {
        [JsonProperty(PropertyName = "Results")]
        public FilmResponse[] Films { get; set; }
    }
    public class FilmResponse
    {
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Episode_Id")]
        public int EpisodeId { get; set; }
        public string Director { get; set; }

        [JsonProperty(PropertyName = "Release_Date")]
        public string ReleaseDate { get; set; }
        public string[] Characters { get; set; }
    }

    public class Film
    {
        public string Title { get; set; }
        public int Episode { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }
        public List<CharacterApiResponse> Characters { get; set; }
    }
}
