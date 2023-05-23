using Aplication.Dtos;
using Aplication.Services;
using Infrastructure.Persistance.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryControler
    {
        private readonly ICategoryService _categoryService;


        public CategoryControler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name = "GetAllCategory")]
        public IEnumerable<CategoryDto> GetAll() {
            return _categoryService.GetAll();
        }

        [HttpGet]
        [Route("GetCategiryByid")]
        public CategoryDto GetCategoryByID(int id)
        {
            return _categoryService.GetById(id);
        }

        [HttpPost]
        [Route("AddCategory")]
        public CategoryDto AddCategory(CategoryDto category)
        {
            return _categoryService.Add(category);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public CategoryDto DeleteCategory(CategoryDto categoryDto) { 
            return _categoryService.Delete(categoryDto);
        }

        [HttpPatch]
        [Route("UpdateCategory")]
        public CategoryDto UpdateCategory(CategoryDto category)
        {
            return _categoryService.Update(category);
        }
    }
}
