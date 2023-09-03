using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net.Data;
using net.Domain;
using net.Models.DTO;

namespace net.Controllers
{   
    // /api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var categoty = new Category 
            { 
                Name = request.Name, 
                UrlHandle = request.UrlHandle 
            };

            await dbContext.Categories.AddAsync(categoty);
            await dbContext.SaveChangesAsync();

            var response = new CategoryDto
            { 
              Id = categoty.Id,
              Name = request.Name,
              UrlHandle = categoty.UrlHandle 
            };

            return Ok(response);
        }
    }
}
