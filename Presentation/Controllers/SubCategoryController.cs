using Aplication.Dtos;
using Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoryController
    {
        private readonly ISubCategoryService subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }

        [HttpGet(Name = "GetAllSubCategory")]
        public IEnumerable<SubCategoryDto> GetAll()
        {
            return subCategoryService.GetAll();
        }

        [HttpGet]
        [Route("GetSubCategoryById")]
        public SubCategoryDto GetById(int id)
        {
            return subCategoryService.GetById(id);
        }

        [HttpDelete]
        [Route("DeletSubCategory")]
        public ActionResult<SubCategoryDto> Delete(SubCategoryDto dto)
        {
            return new OkObjectResult(subCategoryService.Delete(dto));
        }

        [HttpPost]
        [Route("AddSubCategory")]
        public ActionResult<SubCategoryDto> Add(SubCategoryDto dto)
        {
            return new OkObjectResult(subCategoryService.Add(dto));
        }

        [HttpPost]
        [Route("AddSubCategoryName")]
        public ActionResult<SubCategoryDto> Add(string a)
        {
            return new OkObjectResult(subCategoryService.Add(a));
        }

        [HttpPatch]
        [Route("UpdateSubCategory")]
        public SubCategoryDto Update(SubCategoryDto dto)
        {
            return subCategoryService.Update(dto);
        }
    }
}
