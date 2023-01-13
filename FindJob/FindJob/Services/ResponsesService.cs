using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FindJob.Models;
using Newtonsoft.Json;

namespace FindJob.Services
{
	public class ResponsesService
	{

       /* public async Task<List<Responses>>GetResponsesList()
        {
            List<Responses> responses = new List<Responses>();

            using(HttpClient client = new HttpClient())
            {

            }
            
        }*/


        public async Task<bool> GetResponseByVacancyId(string id)
        {
            bool answers;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync($"http://192.168.1.4:5032/api/Responses/{id}");
                answers = JsonConvert.DeserializeObject<bool>(await response);
                if (answers.ToString() == "false") return false;
            }
            return answers;
        }

        public async Task<Responses> PostResponse(Responses answer)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = JsonConvert.SerializeObject(answer);
                var fin = new StringContent(request, Encoding.UTF8, "application/json");
               
                var result = await client.PostAsync("http://192.168.1.4:5032/api/Responses", fin);
                var ou = JsonConvert.DeserializeObject<Responses>(await result.Content.ReadAsStringAsync());

                return ou;
            }
        }
    }
}

