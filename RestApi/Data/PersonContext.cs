using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Data
{
    public sealed class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
        public PersonContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}