using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ThingsController : ControllerBase
    {
        private IUnitOfWork Uow;

        public ThingsController(IUnitOfWork uow) 
        {
            this.Uow = uow;
        }

        // GET api/things/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Thing>?> GetThingById(int id)
        {
            var thing = await Uow.ThingsRepository.GetOne(id);

            if (thing == null)
                return this.BadRequest();
            return thing;
        }

        // GET api/things
        [HttpGet]
        public async Task<ActionResult<List<Thing>?>> GetAllThings()
        {
            return await Uow.ThingsRepository.GetAll();
        }

        // POST api/things
        [HttpPost]
        public async Task<ActionResult<int>> AddThing(Thing thing)
        {
            var category = await Uow.CategoriesRepository.GetOne(thing.Category.Id);

            if (category == null)
                return this.BadRequest();
            thing.Category = category;

            try
            {
                int id = await Uow.ThingsRepository.Add(thing);
                Uow.SaveChangesAsync();
                return id;
            } catch (Exception e)
            {
                return this.BadRequest("Error: " + e.Message);
            }
            
        }

        // PUT api/things
        [HttpPut]
        public async Task<ActionResult> UpdateThing(Thing thing)
        {
            var category = await Uow.CategoriesRepository.GetOne(thing.Category.Id);

            if (category == null)
                return this.BadRequest();
            thing.Category = category;

            try
            {
                await Uow.ThingsRepository.Update(thing);
                Uow.SaveChangesAsync();
                return this.NoContent();
            } catch (Exception e)
            {
                return this.BadRequest("Error: " + e.Message);
            }
            
        }

        // DELETE api/things/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteThing(int id)
        {
            var thing = await Uow.ThingsRepository.GetOne(id);

            if (thing == null)
                return this.BadRequest();

            await Uow.ThingsRepository.Delete(thing);
            Uow.SaveChangesAsync();
            return this.NoContent();
        }
    }
}
