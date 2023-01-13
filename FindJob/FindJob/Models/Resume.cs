using System;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;
using FindJob.Services;
using Xamarin.Essentials;


namespace FindJob.Models
{
	public class Resume
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("age")]
        public int age { get; set; }

        [JsonPropertyName("desireWork")]
        public string desireWork { get; set; }

        [JsonPropertyName("desireSalary")]
        public string desireSalary { get; set; }

        [JsonPropertyName("employmentDegree")]
        public string employmentDegree { get; set; }

        [JsonPropertyName("education")]
        public string education { get; set; }

        [JsonPropertyName("educationDegree")]
        public string educationDegree { get; set; }

        [JsonPropertyName("graduationYear")]
        public int graduationYear { get; set; }

        [JsonPropertyName("expirience")]
        public int expirience { get; set; }

        [JsonPropertyName("publishTime")]
        public DateTime publishTime { get; set; }

        [JsonPropertyName("skills")]
        public string skills { get; set; }

        [JsonPropertyName("languages")]
        public string languages { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;

        [JsonPropertyName("userId")]
        public string userId { get; set; }

        [JsonPropertyName("photoName")]
        public string photoName { get; set; }

        [JsonPropertyName("photoFile")]
        [JsonConverter(typeof(StreamStringConverter))]
       // public FileStream photoFile { get; set; }
       public MultipartFormDataContent photoFile { get; set; }
       

        [JsonPropertyName("photoSrc")]
        public string photoSrc { get; set; }
    }
}

