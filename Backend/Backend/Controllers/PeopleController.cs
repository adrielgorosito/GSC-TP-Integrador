using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork Uow;

        public PeopleController(IUnitOfWork uow)
        {
            this.Uow = uow;
        }

        // GET api/people/{dni}
        [HttpGet("{dni}")]
        public async Task<ActionResult<Person>?> GetPersonByDni(int dni)
        {
            var person = await Uow.PeopleRepository.GetOne(dni);

            if (person == null)
                return this.NotFound();
            return person;
        }

        // GET api/people
        [HttpGet]
        public async Task<ActionResult<List<Person>?>> GetPeople()
        {
            return await Uow.PeopleRepository.GetAll();
        }

        // POST /api/people
        [HttpPost]
        public async Task<ActionResult> AddPerson(Person person)
        {
            try
            {
                await Uow.PeopleRepository.Add(person);
                Uow.SaveChangesAsync();
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest("Error: " + e.Message);
            }
        }

        // PUT /api/people/
        [HttpPut]
        public async Task<ActionResult> UpdatePerson(Person person)
        {
            var personDb = await Uow.PeopleRepository.GetOne(person.Dni);

            if (personDb == null)
                return this.NotFound();

            await Uow.PeopleRepository.Update(person);
            Uow.SaveChangesAsync();

            return this.NoContent();
        }

        // DELETE /api/people/{dni}
        [HttpDelete("{dni}")]
        public async Task<ActionResult> DeletePerson(int dni)
        {
            var person = await Uow.PeopleRepository.GetOne(dni);

            if (person == null)
                return this.NotFound();

            await Uow.PeopleRepository.Delete(person);
            Uow.SaveChangesAsync();
            return this.NoContent();
        }
    }
}
