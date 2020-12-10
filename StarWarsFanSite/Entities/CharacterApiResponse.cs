namespace StarWarsFanSite.Entities
{
    public class CharacterApiResponse : BaseApiEntity
    {
        public string Birth_Year { get; set; }
        public string Eye_Color { get; set; }
        public string[] Films { get; set; }
        public string Gender { get; set; }
        public string Hair_Color { get; set; }
        public string Height { get; set; }
        public string Homeworld { get; set; }
        public string Mass { get; set; }
        public string Name { get; set; }
        public string SkinColor { get; set; }
        public string[] Species { get; set; }
        public string[] Starships { get; set; }
        public string[] Vehicles { get; set; }
    }
}
