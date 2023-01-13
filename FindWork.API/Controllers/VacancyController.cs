using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindWork.API.Data;
using FindWork.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FindWork.API.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly DataContext _context;

        public VacancyController(DataContext context) { _context = context; }

      public List<Vacancy> vacancies { get; set; } = new List<Vacancy>();

        [HttpGet]
        public async Task<ActionResult<List<Vacancy>>>GetVacancies() {

            vacancies = await _context.vacancies.ToListAsync();

            string newname = "";

            foreach(var vacancy in vacancies)
            {
                if(vacancy.vacancyname.Length>15)
                {
                    for(int i=0;i<13;i++)
                    {
                        newname += vacancy.vacancyname[i];
                    }
                    newname += "...";
                    vacancy.vacancyname = newname;
                    newname = "";
                }
            
            }
            return  Ok(vacancies); 
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> GetVacancyById(string id)
        {
            return Ok(await _context.vacancies.FirstAsync(x=>x.vacancyId.ToString()==id));

        }

        [HttpGet("responses/{id}")]
        public async Task<ActionResult<List<Vacancy>>>GetRespondedVacancies(string id)
        {
            var responses = await _context.responses.Where(x=>x.WorkerId==id).ToListAsync();

            List<Vacancy> returnList = new List<Vacancy>();
            for(int i=0;i<responses.Count;i++)
            {
                returnList.Add(await _context.vacancies.FirstAsync(x => x.vacancyId == responses[i].VacancyId));
            }
            return returnList;
        }

        [HttpGet("find/{vacancy}")]
        public  ActionResult<List<Vacancy>>FindVacancies(string vacancy)
        { 
            vacancies = vacancies.Where(s => s.vacancyname.ToLower().Contains(vacancy.ToLower())
            || s.description.ToLower().Contains(vacancy.ToLower())
            || s.category.ToLower().Contains(vacancy.ToLower())).ToList();
            //  vacancies =await _context.vacancies.Where()  //(x=>x.vacancyname==vacancy);

            return vacancies;
        }

/*
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Vacancy>>>GetVacanciesByName(string name){
            List<Vacancy>vacancies =await _context.vacancies.Where(x=>x.vacancyname==name).ToListAsync();
            return Ok(vacancies);
        }*/

        [HttpPost]
        public async Task<ActionResult<Vacancy>> PostVacancy(Vacancy vacancy)
        {
            _context.vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
             return CreatedAtAction("GetUser", new { id = vacancy.vacancyId }, vacancy);
        }
        
    }
}