using Backend.DataAccess;
using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
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
            int generatedId = await Uow.CategoriesRepository.Add(category);
            Uow.SaveChangesAsync();
            return generatedId;
        }

        // PUT /api/categories/
        [HttpPut]
        public async Task<ActionResult> UpdateCategory(Category category)
        {
            await Uow.CategoriesRepository.Update(category);
            Uow.SaveChangesAsync();

            return this.NoContent();
        }

        // PUT /api/categories/{id}
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
