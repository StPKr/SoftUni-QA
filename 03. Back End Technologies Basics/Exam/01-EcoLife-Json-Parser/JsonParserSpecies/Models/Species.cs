using System.Text.Json.Serialization;


namespace JsonParser.Models
{

    public class Species
    {
        [JsonPropertyName("speciesId")]
        public int SpeciesId { get; set; }

        [JsonPropertyName("speciesName")]
        public string SpeciesName { get; set; }

        [JsonPropertyName("habitat")]
        public string Habitat { get; set; }

        [JsonPropertyName("lifespan")]
        public int Lifespan { get; set; }

        [JsonPropertyName("habits")]
        public Habits Habits { get; set; }
    }

    public class Habits
    {
        [JsonPropertyName("diet")]
        public List<string> Diet { get; set; }

        [JsonPropertyName("migration")]
        public string Migration { get; set; }
    }
}

