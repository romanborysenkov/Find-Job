using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FindJob.Models;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using FindJob.Interfaces;

namespace FindJob.Services
{
    public class VacanciesService:IVacancies
    {
        public async Task<List<Vacancy>> GetVacanciesAsync()
        {
            List<Vacancy> vacancies;

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 0, 5);
                var response = await client.GetStringAsync("http://192.168.1.7:5032/api/Vacancy");

                vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(response);
                return vacancies;
            }
        }

        public async Task<List<Vacancy>>GetRespondedVacancies()
        {
            List<Vacancy> vacancies;

            string id = Preferences.Get("userId", "");

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0,0,0,5);
                var response = await client.GetStringAsync($"http://192.168.1.7:5032/api/Vacancy/responses/{id}");

                vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(response);
                return vacancies;
            }
        }

        public async Task<Vacancy> GetVacancyById(string id)
        {
            var vacancy = new Vacancy();
            using (HttpClient client = new HttpClient())
            {

                var response = await client.GetStringAsync($"http://192.168.1.7:5032/api/Vacancy/{id}");
                vacancy = JsonConvert.DeserializeObject<Vacancy>(response);
            }
            return vacancy;
        }
                /*vacancies.Where(s => s.vacancyname.ToLower().Contains(SearchString.ToLower())
            || s.description.ToLower().Contains(SearchString.ToLower())
            || s.category.ToLower().Contains(SearchString.ToLower())).ToList();*/

              
    }
}

