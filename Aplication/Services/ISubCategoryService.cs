using Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface ISubCategoryService
    {
        IEnumerable<SubCategoryDto> GetAll();
        SubCategoryDto GetById(int id);
        SubCategoryDto Add(SubCategoryDto categoryDto);
        SubCategoryDto Add(string subCategory);
        SubCategoryDto Update(SubCategoryDto categoryDto);
        SubCategoryDto Delete(SubCategoryDto category);
    }
}
