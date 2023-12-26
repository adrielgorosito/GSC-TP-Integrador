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
            DataSeeding DataSeeding = new DataSeeding();

            modelBuilder.Entity<Person>(p =>
            {
                p.HasKey(per => per.Dni);
                p.Property(per => per.Dni).ValueGeneratedNever();
                p.HasData(DataSeeding.People);
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.HasIndex(cat => cat.Description).IsUnique();
                c.Property(cat => cat.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                c.HasData(DataSeeding.Categories);
            });

            modelBuilder.Entity<Thing>(t =>
            {
                t.HasIndex(th => th.Description).IsUnique();
                t.Property(th => th.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                t.HasData(DataSeeding.Things);
            });

            modelBuilder.Entity<Loan>(l =>
            {
                l.Property(lo => lo.Status).HasDefaultValue(LoanStatus.Pending);
                l.HasData(DataSeeding.Loans);
            });
        }
    }
}
