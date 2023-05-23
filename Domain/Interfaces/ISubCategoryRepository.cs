using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubCategoryRepository
    {
        SubCategory GetById(int id);
        List<SubCategory> FindAll();
        SubCategory Add(SubCategory subCategory);
        SubCategory Update(SubCategory subCategory);
        SubCategory Delete(SubCategory subCategory);
        SubCategory AddByName(string subCategory);
    }
}
