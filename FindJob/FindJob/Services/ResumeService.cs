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
	public class ResumeService
	{
        public async Task<List<Resume>> GetResumesAsync()
        {
            List<Resume> resumes;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync("http://192.168.1.4:5032/api/Resume");
                resumes = JsonConvert.DeserializeObject<List<Resume>>(await response);

            }
            return resumes;
        }

        public async Task<Resume>GetResumeByUserId(string id)
        {
            Resume resume = new Resume();
            using(HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync($"http://192.168.1.4:5032/api/Resume/user/{id}");
                resume = JsonConvert.DeserializeObject<Resume>(await response);
                if(response.Result.Length==0)
                {
                    return new Resume();
                }
            }
            return resume;
        }   

        public async Task<Resume> PostResume(Resume resume)
        {
            using (HttpClient client = new HttpClient())
            {
                resume.photoFile = null;
                var request = JsonConvert.SerializeObject(resume);
                var fin = new StringContent(request, Encoding.UTF8, "application/json");
                 resume.photoSrc = JsonConvert.SerializeObject(resume.photoFile);
                var result = await client.PostAsync("http://192.168.1.4:5032/api/Resume", fin);
                var ou = JsonConvert.DeserializeObject<Resume>(await result.Content.ReadAsStringAsync());

                 return ou;
            }
        }

        public async Task PutResume(Resume resume)
        {
            using (HttpClient client = new HttpClient())
            {
                // post image
                if (resume.photoFile != null)
                {
                    await client.PostAsync("http://192.168.1.4:5032/api/Resume/UploadFile", resume.photoFile);
                }

                resume.photoFile = null;
                var request = JsonConvert.SerializeObject(resume);
                var fin = new StringContent(request, Encoding.UTF8, "application/json");
                var result = await client.PutAsync("http://192.168.1.4:5032/api/Resume", fin);
               // var ou = JsonConvert.DeserializeObject<Resume>(await result.Content.ReadAsStringAsync());

               // return ou;
            }
        }
    }
}

