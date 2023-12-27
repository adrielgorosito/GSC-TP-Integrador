using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

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
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoanDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(p =>
            {
                p.HasKey(per => per.Dni);
                p.Property(per => per.Dni).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.HasIndex(cat => cat.Description).IsUnique();
                c.Property(cat => cat.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Thing>(t =>
            {
                t.HasIndex(th => th.Description).IsUnique();
                t.Property(th => th.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Loan>(l =>
            {
                l.Property(lo => lo.Status).HasDefaultValue(LoanStatus.Pending);
            });

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                // Data seeding will only be done if we are in a development environment
                // The reason is not to interfere with testing
                DataSeeding DataSeeding = new DataSeeding();

                modelBuilder.Entity<Person>().HasData(DataSeeding.People);
                modelBuilder.Entity<Category>().HasData(DataSeeding.Categories);
                modelBuilder.Entity<Thing>().HasData(DataSeeding.Things);
                modelBuilder.Entity<Loan>().HasData(DataSeeding.Loans);
            }
        }
    }
}
