using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repository
{
    //Rpozytorium obsługujący tabele kategoria wykonaywane są tu operacje bezpośrednio na bazie danych 
    public class CategoryRepository : ICategoryRepository
    {
        //Zmienna reprezętująca kontekst bazy danych 
        private readonly ApiDbContext _context;
        public CategoryRepository(ApiDbContext context) {
            _context = context;
        }

        //Metoda add w której jest dodawana nowa encaja
        public Category Add(Category category)
        {
            var w = _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        //Metoda Delet usówa encje z bazy danych 
        public Category Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
        //Metoda FindAll zwraca wszystkie rkordy z bazy danych 
        public List<Category> FindAll()
        {
            var returnval =_context.Categories.ToList();
            return returnval;
        }
        //Metoda Get By id zwraca rekord po podaniu jego id
        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }
        //Metoda update 
        public Category Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}
