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
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<List<User>>>GetUsers() { 
            List<User>users = await _context.users.ToListAsync();
            return  Ok(users); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>>GetUserById(string id) { return (await _context.users.FindAsync(id)); }


            [HttpGet("{email}/{password}")]
                public async Task<ActionResult<User>> LoginUser(string email, string password)
                {
                    try{
                    var user =await _context.users.FirstAsync(x=>x.email==email);
                if (user.salt == password)
                {
                    return Ok(user);
                }
                else return new User();
                 }
            catch  { return new User(); }

                } 

        [HttpPut]
        public async Task<ActionResult<User>> PutUser([FromBody]User user)
        {
            _context.users.Update(user);

            await _context.SaveChangesAsync();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try{
                var result =await _context.users.FirstAsync(x=>x.email==user.email);
               
                  return BadRequest();
                
            }
            catch{
            user.Id =new IdentityUser().Id;
            _context.users.Add(user);
            await _context.SaveChangesAsync();
              return user;
            }
        }   
    }
}