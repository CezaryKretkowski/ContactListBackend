using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance.Data;

namespace Infrastructure.Persistance.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        //Zmienna reprezętująca kontekst bazy danych 
        private readonly ApiDbContext _context;

        //Konstuktor repozytorium
        public SubCategoryRepository(ApiDbContext context)
        {
            _context = context;
        }
        //Metoda add w której jest dodawana nowa encaja
        public SubCategory Add(SubCategory subCategory)
        {
            subCategory.Category = _context.Categories.FirstOrDefault(c => c.Id == subCategory.CategoryId);
            _context.SubCategories.Add(subCategory);
            _context.SaveChanges();
            return subCategory;
        }
        //Metoda add w której jest dodawana nowa encaja jako paramter przyjmuję nazwę nowej pod kategori
        public SubCategory AddByName(string subCategory) {
            int last = _context.SubCategories.ToList().Last().Id;
            SubCategory s = new SubCategory();
            s.Id = last+1;
            s.Name = subCategory;
            s.CategoryId = 3;
            s.Category =_context.Categories.FirstOrDefault(c => c.Id == 3);
            _context.SubCategories.Add(s);
            _context.SaveChanges();
            return s;
        }
        //Metoda Delet usówa encje z bazy danych 
        public SubCategory Delete(SubCategory subCategory)
        {
            
            _context.SubCategories.Remove(subCategory);
            _context.SaveChanges();
            return subCategory;
        }
        //Metoda FindAll zwraca wszystkie rkordy z bazy danych 
        public List<SubCategory> FindAll()
        {   List<SubCategory> s =_context.SubCategories.ToList();
            foreach (var index in s) {
                index.Category = _context.Categories.FirstOrDefault(c => c.Id == index.CategoryId);
            }

            return s;
        }
        //Metoda Get By id zwraca rekord po podaniu jego id
        public SubCategory GetById(int id)
        {
            SubCategory s  = _context.SubCategories.FirstOrDefault(x => x.Id == id);
            if (s == null)
                return null;
            s.Category= _context.Categories.FirstOrDefault(c => c.Id == s.CategoryId);
            return s;
        }
        //Metoda update 
        public SubCategory Update(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            _context.SaveChanges();
            return subCategory;
        }
    }
}
