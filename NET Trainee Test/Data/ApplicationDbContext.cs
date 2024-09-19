using Microsoft.EntityFrameworkCore;
using NET_Trainee_Test.Models;
using System.Collections.Generic;

namespace NET_Trainee_Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }

}
