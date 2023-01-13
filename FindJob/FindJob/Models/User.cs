using System;
using System.Text.Json.Serialization;

namespace FindJob.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("firstname")]
        public string firstname { get; set; } = string.Empty;

        [JsonPropertyName("secondname")]
        public string secondname { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("salt")]
        public string salt { get; set; } = string.Empty;

        [JsonPropertyName("saltedhashedpassword")]
        public string saltedhashedpassword { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; } = string.Empty;

        [JsonPropertyName("isEmployer")]
        public bool isEmployer { get; set; }
    }
}

