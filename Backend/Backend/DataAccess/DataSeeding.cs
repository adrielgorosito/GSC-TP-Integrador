using Backend.Domain;

namespace Backend.DataAccess
{
    public class DataSeeding
    {
        public HashSet<Category> Categories;
        public HashSet<Person> People;
        public HashSet<dynamic> Things;
        public HashSet<object> Loans;

        public DataSeeding()
        {
            Categories = new HashSet<Category>
            {
                new Category() { Id = 1, Description = "Electronics" },
                new Category() { Id = 2, Description = "Furniture" },
                new Category() { Id = 3, Description = "Clothing" },
                new Category() { Id = 4, Description = "Books" },
                new Category() { Id = 5, Description = "Home Appliances" }
            };

            People = new HashSet<Person>
            {
                new Person()
                {
                    Dni = 42125750,
                    Name = "Adriel",
                    PhoneNumber = "3476123456",
                    EmailAddress = "adrielgorosito14@gmail.com"
                },
                new Person()
                {
                    Dni = 42000000,
                    Name = "Beto",
                    PhoneNumber = "341123456",
                    EmailAddress = "betorc@gsc.com"
                },
                new Person()
                {
                    Dni = 42123456,
                    Name = "Walter",
                    PhoneNumber = "341654321",
                    EmailAddress = "walter@gsc.com"
                }
            };

            Things = new HashSet<object>
            {
                new { Id = 1, Description = "Notebook", CategoryId = Categories.First(c => c.Id == 1).Id },
                new { Id = 2, Description = "Smartphone", CategoryId = Categories.First(c => c.Id == 1).Id },
                new { Id = 3, Description = "Sofa", CategoryId = Categories.First(c => c.Id == 2).Id },
                new { Id = 4, Description = "T-shirt", CategoryId = Categories.First(c => c.Id == 3).Id },
                new { Id = 5, Description = "Jeans", CategoryId = Categories.First(c => c.Id == 3).Id },
                new { Id = 6, Description = "Sweater", CategoryId = Categories.First(c => c.Id == 3).Id },
                new { Id = 7, Description = "Socks", CategoryId = Categories.First(c => c.Id == 3).Id },
                new { Id = 8, Description = "Shorts", CategoryId = Categories.First(c => c.Id == 3).Id },
                new { Id = 9, Description = "Speaker", CategoryId = Categories.First(c => c.Id == 5).Id }
            };

            Loans = new HashSet<dynamic>
            {
                new { Id = 1, Date = new DateOnly(2023, 12, 1), ReturnDate = new DateOnly(2023, 12, 3), Status = LoanStatus.Returned, PersonDni = People.First(p => p.Name == "Adriel").Dni, ThingId = Things.First(t => t.Id == 1).Id },
                new { Id = 2, Date = new DateOnly(2023, 12, 2), Status = LoanStatus.Pending, PersonDni = People.First(p => p.Name == "Beto").Dni, ThingId = Things.First(t => t.Id == 2).Id },
                new { Id = 3, Date = new DateOnly(2023, 12, 3), ReturnDate = new DateOnly(2023, 12, 5), Status = LoanStatus.Returned, PersonDni = People.First(p => p.Name == "Walter").Dni, ThingId = Things.First(t => t.Id == 3).Id },
                new { Id = 4, Date = new DateOnly(2023, 12, 4), Status = LoanStatus.Pending, PersonDni = People.First(p => p.Name == "Adriel").Dni, ThingId = Things.First(t => t.Id == 4).Id },
                new { Id = 5, Date = new DateOnly(2023, 12, 5), Status = LoanStatus.Pending, PersonDni = People.First(p => p.Name == "Beto").Dni, ThingId = Things.First(t => t.Id == 5).Id },
                new { Id = 6, Date = new DateOnly(2023, 12, 6), Status = LoanStatus.Pending, PersonDni = People.First(p => p.Name == "Walter").Dni, ThingId = Things.First(t => t.Id == 6).Id },
                new { Id = 7, Date = new DateOnly(2023, 12, 7), ReturnDate = new DateOnly(2023, 12, 11), Status = LoanStatus.Returned, PersonDni = People.First(p => p.Name == "Adriel").Dni, ThingId = Things.First(t => t.Id == 7).Id },
                new { Id = 8, Date = new DateOnly(2023, 12, 8), Status = LoanStatus.Pending, PersonDni = People.First(p => p.Name == "Beto").Dni, ThingId = Things.First(t => t.Id == 8).Id },
                new { Id = 9, Date = new DateOnly(2023, 12, 9), ReturnDate = new DateOnly(2023, 12, 20), Status = LoanStatus.ReturnedLate, PersonDni = People.First(p => p.Name == "Walter").Dni, ThingId = Things.First(t => t.Id == 9).Id },
                new { Id = 10, Date = new DateOnly(2023, 12, 10), Status = LoanStatus.Pending, PersonDni = People.First(p => p.Name == "Adriel").Dni, ThingId = Things.First(t => t.Id == 2).Id },
            };
        }
    }
}
