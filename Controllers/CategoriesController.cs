using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net.Data;
using net.Domain;
using net.Models.DTO;
using net.Repositories.Interface;

namespace net.Controllers
{   
    //
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository) 
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category 
            { 
                Name = request.Name, 
                UrlHandle = request.UrlHandle 
            };

            await categoryRepository.CreateAsync(category);

            var response = new CategoryDto
            { 
              Id = category.Id,
              Name = request.Name,
              UrlHandle = category.UrlHandle 
            };

            return Ok(response);
        }
    }
}
