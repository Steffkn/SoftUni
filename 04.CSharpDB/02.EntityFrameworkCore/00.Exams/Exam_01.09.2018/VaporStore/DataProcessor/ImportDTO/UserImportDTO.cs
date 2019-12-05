using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ImportDTO
{
    public class UserImportDTO
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("Cards")]
        public CardImportDTO[] Cards { get; set; }
    }

    public class CardImportDTO
    {
        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("CVC")]
        public string CVC { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
