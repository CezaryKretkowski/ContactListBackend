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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository){
            _subCategoryRepository = subCategoryRepository;
        }
        public SubCategoryDto Add(SubCategoryDto categoryDto)
        {
            SubCategory sc=new SubCategory();
            sc.CategoryId = categoryDto.CategoryId;
            sc.Id = categoryDto.Id;
            sc.Name = categoryDto.Name;
            _subCategoryRepository.Add(sc);
            return categoryDto;
            
        }

        public SubCategoryDto Add(string subCategory)
        {
            SubCategory s = _subCategoryRepository.AddByName(subCategory);
            SubCategoryDto w = new SubCategoryDto(s.Id,s.Name,(int)s.CategoryId,new CategoryDto(s.Category.Id,s.Category.Name));
            return w;
        }

        public SubCategoryDto Delete(SubCategoryDto categoryDto)
        {
            SubCategory sc = new SubCategory();
            sc.CategoryId = categoryDto.CategoryId;
            sc.Id = categoryDto.Id;
            sc.Name = categoryDto.Name;
            _subCategoryRepository.Delete(sc);
            return categoryDto;
        }

        public IEnumerable<SubCategoryDto> GetAll()
        {
            List<SubCategoryDto> list = new List<SubCategoryDto>();
            foreach (var i in _subCategoryRepository.FindAll())
            {
                CategoryDto s = new CategoryDto(i.Category.Id,i.Category.Name);
                list.Add(new SubCategoryDto(i.Id, i.Name, i.Category.Id,s));
            
            }
            return list;
        }

        public SubCategoryDto GetById(int id)
        {
            SubCategory sc = _subCategoryRepository.GetById(id);
            CategoryDto categoryDto = new CategoryDto(sc.Id,sc.Name);
            return new SubCategoryDto(sc.Id, sc.Name, sc.Category.Id,categoryDto);

        }

        public SubCategoryDto Update(SubCategoryDto categoryDto)
        {
            SubCategory sc = new SubCategory();
            sc.CategoryId = categoryDto.CategoryId;
            sc.Id = categoryDto.Id;
            sc.Name = categoryDto.Name;
            _subCategoryRepository.Update(sc);
            return categoryDto;
        }
    }
}
