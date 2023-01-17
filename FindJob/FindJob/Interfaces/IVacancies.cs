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



namespace FindJob.Interfaces
{
	public interface IVacancies
	{
		Task<List<Vacancy>> GetVacanciesAsync();

		Task<List<Vacancy>> GetRespondedVacancies();

		Task<Vacancy> GetVacancyById(string id);

    }
}

