using System;
using System.Text.Json.Serialization;

namespace FindJob.Models
{
	public class Vacancy
	{
        [JsonPropertyName("vacancyId")]
        public int vacancyId { get; set; }

        [JsonPropertyName("vacancyname")]
        public string vacancyname { get; set; }

        [JsonPropertyName("company")]
        public string company { get; set; }

        [JsonPropertyName("category")]
        public string category { get; set; }

        [JsonPropertyName("publishtime")]
        public DateTime publishtime { get; set; }

        [JsonPropertyName("salary")]
        public int salary { get; set; }

        [JsonPropertyName("location")]
        public string location { get; set; }

        [JsonPropertyName("requires")]
        public string requires { get; set; }

        [JsonPropertyName("offer")]
        public string offer { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("userId")]
        public string userId { get; set; }
    }
}

