using Backend.Controllers;
using Backend.DataAccess;
using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests.Unit.Controllers
{
    public class PeopleControllerTests : IDisposable
    {
        private readonly SqliteConnection connection = new("Filename=:memory:");
        private readonly LoanDbContext context;
        private readonly IUnitOfWork Uow;
        private readonly PeopleController sut;

        public PeopleControllerTests()
        {
            this.connection.Open();
            var options = new DbContextOptionsBuilder().UseSqlite(this.connection).Options;
            this.context = new LoanDbContext(options);
            this.Uow = new UnitOfWork(this.context);
            this.sut = new PeopleController(this.Uow);
        }

        public void Dispose() => this.connection.Dispose();

        private async Task InitAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.context.AddRangeAsync(
                new Person() { Dni = 1, Name = "Adriel", PhoneNumber = "123", EmailAddress = "adriel@g.com"},
                new Person() { Dni = 2, Name = "Walter", PhoneNumber = "111", EmailAddress = "walter@g.com" },
                new Person() { Dni = 3, Name = "Beto", PhoneNumber = "321", EmailAddress = "betorc@g.com" }
            );

            await this.context.SaveChangesAsync();
        }

        public class TheMethod_GetPersonByDni() : PeopleControllerTests
        {
            [Fact]
            public async Task Should_return_person_with_dni_equals_one()
            {
                // arrange
                await this.InitAsync();

                // act
                ActionResult<Person>? actual = await this.sut.GetPersonByDni(1);

                // assert
                actual.Value.Should().NotBeNull();
                Person personWithDniOne = actual.Value;

                using (new AssertionScope())
                {
                    personWithDniOne!.Dni.Should().Be(1);
                    personWithDniOne!.Name.Should().Be("Adriel");
                    personWithDniOne!.PhoneNumber.Should().Be("123");
                    personWithDniOne!.EmailAddress.Should().Be("adriel@g.com");
                }

                this.Dispose();
            }

            [Fact]
            public async Task Should_return_error_NotFound_when_person_does_not_exists()
            {
                // arrange
                await this.InitAsync();

                // act
                ActionResult<Person?> actual = await this.sut.GetPersonByDni(100);

                // assert
                actual.Result.Should().BeOfType<NotFoundResult>();
                actual.Value.Should().BeNull();

                this.Dispose();
            }
        }
    }
}