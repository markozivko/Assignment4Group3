using Microsoft.AspNetCore.Mvc;
using Assignment4Group3;
using Microsoft.Extensions.Configuration;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/categories")]

    public class CategoriesController : ControllerBase
    {
        private readonly string _connectionString;

        public CategoriesController()
        {
             var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();
            _connectionString = config["connectionString"];
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            var dataService = new DataService(_connectionString);
            var categories = dataService.GetCategories();

            return new JsonResult(categories);
        }

        //with error handling included
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var dataService = new DataService(_connectionString);
            var category = dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category categoryCreated)
        {
            var dataService = new DataService(_connectionString);

            var category = new Category
            {
                Name = categoryCreated.Name,
                Description = categoryCreated.Description
            };

            dataService.CreateCategory(category.Name, category.Description);
            return Created("", category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category categoryUpdated)
        {
            var dataService = new DataService(_connectionString);

            var category = new Category
            {
                Id = id,
                Name = categoryUpdated.Name,
                Description = categoryUpdated.Description
            };

            if (!dataService.UpdateCategory(id, category.Name, category.Description))
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
