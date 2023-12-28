using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork Uow;

        public CategoriesController(IUnitOfWork uow)
        {
            this.Uow = uow;   
        }

        // GET api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>?> GetCategoryById(int id)
        {
            var category = await Uow.CategoriesRepository.GetOne(id);

            if (category == null)
                return this.NotFound();
            return category;
        }

        // GET api/categories
        [HttpGet]
        public async Task<ActionResult<List<Category>?>> GetCategories()
        {
            return await Uow.CategoriesRepository.GetAll();
        }

        // POST /api/categories
        [HttpPost]
        public async Task<ActionResult<int>> AddCategory(Category category)
        {
            try
            {
                int generatedId = await Uow.CategoriesRepository.Add(category);
                Uow.SaveChangesAsync();
                return generatedId;
            } catch (Exception e)
            {
                return this.BadRequest("Error: " + e.Message);
            }
        }

        // PUT /api/categories
        [HttpPut]
        public async Task<ActionResult> UpdateCategory(Category category)
        {
            await Uow.CategoriesRepository.Update(category);
            Uow.SaveChangesAsync();

            return this.NoContent();
        }

        // DELETE /api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await Uow.CategoriesRepository.GetOne(id);

            if (category == null)
                return this.NotFound();
            
            await Uow.CategoriesRepository.Delete(category);
            Uow.SaveChangesAsync();
            return this.NoContent();
        }
    }
}
