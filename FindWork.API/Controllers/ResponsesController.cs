using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindWork.API.Data;
using FindWork.API.Models;

namespace FindWork.API.Controllers
{
     [Route("api/[controller]")]
   
    public class ResponsesController :Controller
    {
        private readonly DataContext _context;
           private readonly IWebHostEnvironment _hostEnvironment;

        public ResponsesController(DataContext context, IWebHostEnvironment hostEnvironment) { _context = context; _hostEnvironment = hostEnvironment; }


        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> GetResponseByVacancyId(int id)
        {

            try
            {
                var result = await _context.responses.FirstAsync(x => x.VacancyId == id);

                if (string.IsNullOrEmpty(result.Id.ToString()))
                {
                    return false;
                }
                else { return true; }
            }
            catch
            {
                return false;
            }
        }
            

        [HttpPost]
        public async Task<ActionResult<Responses>> PostResponse([FromBody]Responses response)
        {
            _context.responses.Add(response);
            await _context.SaveChangesAsync();
           return response;
        }


        
    }
}