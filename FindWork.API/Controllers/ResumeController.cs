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
   
    public class ResumeController :Controller
    {
        private readonly DataContext _context;
           private readonly IWebHostEnvironment _hostEnvironment;

        public ResumeController(DataContext context, IWebHostEnvironment hostEnvironment) { _context = context; _hostEnvironment = hostEnvironment; }

       /*  [HttpGet]
        public async Task<ActionResult<List<Resume>>>GetResumes() { 
            List<Resume>resumes = await _context.resumes.ToListAsync();
            return  resumes; 
        }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>>GetResumeById(int id) {  return (await _context.resumes.FindAsync(id));  }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<Resume>>GetResumeByUserId(string id) {  return (await _context.resumes.FirstAsync(x=>x.userId==id));  }

       

        [HttpPut]
        public async Task<ActionResult<Resume>> PutResume([FromBody]Resume resume)
        {


            var lastresume = await _context.resumes.FirstAsync(x=>x.Id==resume.Id);

            if(string.IsNullOrEmpty(resume.photoName))  resume.photoSrc = lastresume.photoSrc;

            else  resume.photoSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, resume.photoName);

            resume.publishTime = DateTime.Now;  

            _context.resumes.Update(resume);
          
            await _context.SaveChangesAsync(); 
            return resume;
        }

        [HttpPost("{UploadFile}")]
        public async Task<IActionResult> PostImage()
        { 
            var httpRequest = HttpContext.Request;
            if (httpRequest.Form.Files.Count > 0)
            {
                foreach (var file in httpRequest.Form.Files)
                {
                    await SaveImage(file);
                }
            }
            return Ok();
        
        }

        [HttpPost]
        public async Task<ActionResult<Resume>> PostResume([FromBody]Resume resume)
        {
           resume.photoSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, resume.photoName);
            
            resume.publishTime = DateTime.Now;
            _context.resumes.Add(resume);
            await _context.SaveChangesAsync();
           return resume;
        }

         [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            // string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            string imageName = imageFile.FileName;
           // imageName = imageName + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

        }
        
    }
}