using Aplication.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class CategoryService : ICategoryService
    {  
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) { _categoryRepository = categoryRepository; }

        public CategoryDto Add(CategoryDto categoryDto)
        {
            Category c = new Category();
            c.Id = categoryDto.Id;
            c.Name = categoryDto.Name;
            Console.WriteLine(c);
            _categoryRepository.Add(c);
            return categoryDto;
        }

        public CategoryDto Delete(CategoryDto categoryDto)
        {
            Category c = new Category();
            c.Id = categoryDto.Id;
            c.Name = categoryDto.Name;
            _categoryRepository.Delete(c);
            return categoryDto;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            List<Category> c = _categoryRepository.FindAll();
            List<CategoryDto> dtos = new List<CategoryDto>();
            foreach (Category cat in c) {
                dtos.Add(new CategoryDto(cat.Id, cat.Name));
            }
            return dtos;
        }

        public CategoryDto GetById(int id)
        {
            Category c = _categoryRepository.GetById(id);
            if (c != null)
                return new CategoryDto(c.Id, c.Name);
            else return null;
        }

        public CategoryDto Update(CategoryDto categoryDto)
        {
            Category c = new Category();
            c.Id = categoryDto.Id;
            c.Name = categoryDto.Name;
           _categoryRepository.Update(c);
            return categoryDto;
        }
    }
}
