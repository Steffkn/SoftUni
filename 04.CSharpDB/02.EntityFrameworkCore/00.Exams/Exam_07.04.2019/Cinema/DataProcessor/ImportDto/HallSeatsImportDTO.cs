using Newtonsoft.Json;

namespace Cinema.DataProcessor.ImportDto
{
    public class HallSeatsImportDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Is4Dx")]
        public bool Is4Dx { get; set; }

        [JsonProperty("Is3D")]
        public bool Is3D { get; set; }

        [JsonProperty("Seats")]
        public int Seats { get; set; }
    }
}
