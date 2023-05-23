using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        List<Category> FindAll();
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(Category category);


    }
}
