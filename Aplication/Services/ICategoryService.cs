using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Dtos;

namespace Aplication.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        CategoryDto Add(CategoryDto categoryDto);
        CategoryDto Update(CategoryDto categoryDto);
        CategoryDto Delete(CategoryDto category);
    }
}
