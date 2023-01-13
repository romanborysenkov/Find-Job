using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using  FindWork.API.Models;

namespace FindWork.API.Data
{
    public class DataContext: DbContext
        {
            public DataContext(DbContextOptions<DataContext>options):base(options)
            {  }

          public DbSet<User>? users { get; set; }

          public DbSet<Resume>? resumes { get; set; }
            
         //  public DbSet<Worker>? workers { get; set; }
           public DbSet<Vacancy> vacancies { get; set; }
           
           public DbSet<Responses> responses { get; set; }

        public DbSet<InterviewCall> interviewCalls { get; set; }
        }
}