using Backend.DataAccess;
using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/categories/
        [HttpGet]
        public async Task<ActionResult<List<Category>?>> GetCategories()
        {
            return await Uow.CategoriesRepository.GetAll();
        }
    }
}
