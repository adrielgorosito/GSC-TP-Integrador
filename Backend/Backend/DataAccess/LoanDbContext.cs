using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.DataAccess
{
    public class LoanDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LoanDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoanDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(p =>
            {
                p.HasKey(per => per.Dni);
                p.Property(per => per.Dni).ValueGeneratedNever();
                p.Property(per => per.PhoneNumber).HasColumnType("bigint");
            });

            modelBuilder.Entity<Category>()
                .HasIndex(cat => cat.Description).IsUnique();

            modelBuilder.Entity<Thing>()
                .HasIndex(th => th.Description).IsUnique();
        }
    }
}
