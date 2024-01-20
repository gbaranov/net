using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net.Data;
using net.Domain;
using net.Models.DTO;
using net.Repositories.Interface;

namespace net.Controllers
{   
    
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
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
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

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();
            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDto {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });   
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await categoryRepository.GetById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            var response = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };
            return Ok(response);
        }

    }
}
