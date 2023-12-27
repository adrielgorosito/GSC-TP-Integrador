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
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
            
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

        public class TheMethod_GetPeople() : PeopleControllerTests
        {
            [Fact]
            public async Task Should_return_all_three_init_people()
            {
                // arrange
                await this.InitAsync();

                // act
                ActionResult<List<Person>?> actual = await this.sut.GetPeople();

                // assert
                actual.Value.Should().HaveCount(3);

                this.Dispose();
            }
        }
        public class TheMethod_AddPerson : PeopleControllerTests
        {
            [Fact]
            public async Task Should_add_person_successfully()
            {
                // arrange
                await this.InitAsync();
                var newPerson = new Person() { Dni = 4, Name = "Luciano", PhoneNumber = "555", EmailAddress = "diamand@g.com" };

                // act
                ActionResult actual = await this.sut.AddPerson(newPerson);

                // assert
                actual.Should().BeOfType<NoContentResult>();

                this.Dispose();
            }

            [Fact]
            public async Task Should_return_error_BadRequest_when_dni_already_exists()
            {
                // arrange
                await this.InitAsync();
                var duplicatePerson = new Person() { Dni = 1, Name = "GSC", PhoneNumber = "999", EmailAddress = "gsc@g.com" };

                // act
                ActionResult actual = await this.sut.AddPerson(duplicatePerson);

                // assert
                actual.Should().BeOfType<BadRequestObjectResult>();

                this.Dispose();
            }
        }

        public class TheMethod_UpdatePerson : PeopleControllerTests
        {
            [Fact]
            public async Task Should_update_person_successfully()
            {
                // arrange
                await this.InitAsync();
                var updatedPerson = new Person() { Dni = 1, Name = "Gorosito", PhoneNumber = "777", EmailAddress = "gorosito@g.com" };

                // act
                ActionResult actual = await this.sut.UpdatePerson(updatedPerson);

                // assert
                actual.Should().BeOfType<NoContentResult>();

                this.Dispose();
            }

            [Fact]
            public async Task Should_return_NotFound_when_person_does_not_exists()
            {
                // arrange
                await this.InitAsync();
                var nonExistingPerson = new Person() { Dni = 100, Name = "NonExistingPerson", PhoneNumber = "000", EmailAddress = "error@g.com" };

                // act
                ActionResult actual = await this.sut.UpdatePerson(nonExistingPerson);

                // assert
                actual.Should().BeOfType<NotFoundResult>();

                this.Dispose();
            }
        }

        public class TheMethod_DeletePerson : PeopleControllerTests
        {
            [Fact]
            public async Task Should_delete_person_successfully()
            {
                // arrange
                await this.InitAsync();

                // act
                ActionResult actual = await this.sut.DeletePerson(1);

                // assert
                actual.Should().BeOfType<NoContentResult>();

                this.Dispose();
            }

            [Fact]
            public async Task Should_return_NotFound_when_person_does_not_exists()
            {
                // arrange
                await this.InitAsync();

                // act
                ActionResult actual = await this.sut.DeletePerson(100);

                // assert
                actual.Should().BeOfType<NotFoundResult>();

                this.Dispose();
            }
        }

    }
}