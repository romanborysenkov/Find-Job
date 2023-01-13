using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FindJob.Models;
using System.Collections.Generic;
using System.Text;

namespace FindJob.Services
{
    public class UsersService
    {
       public  async Task<List<User>> GetUsersAsync()
        {
            List<User> users;
            using(HttpClient client = new HttpClient())
            {
                 var response = client.GetStringAsync("http://192.168.1.4:5032/api/User");
                 users =JsonConvert.DeserializeObject<List<User>>(await response);
              
            }
            return users; 
        }

        public async Task<User> GetUserById(string id)
        {
            User user;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync($"http://192.168.1.4:5032/api/User/{id}");
                user = JsonConvert.DeserializeObject<User>(await response);

            }
            return user;
        }

        public async Task<User> PostUser(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = JsonConvert.SerializeObject(user);
                var fin = new StringContent(request, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://192.168.1.4:5032/api/User", fin);
               var ou= JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());

                return ou;
            }
        }

        public async Task<User> PutUser(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = JsonConvert.SerializeObject(user);
                var fin = new StringContent(request, Encoding.UTF8, "application/json");
                var result = await client.PutAsync("http://192.168.1.4:5032/api/User", fin);
                var ou = JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());

                return ou;
            }
        }

            public async Task<User>LoginUser(string email, string password)
        {
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetStringAsync($"http://192.168.1.4:5032/api/User/{email}/{password}");
               var user = JsonConvert.DeserializeObject<User>(await result);
                return user;
               
            }
        }

    }
}

