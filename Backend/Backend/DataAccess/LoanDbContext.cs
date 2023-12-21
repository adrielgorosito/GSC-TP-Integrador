using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class LoanDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
