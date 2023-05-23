using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public int CategoryId { get; set; }
      
        public virtual CategoryDto Category { get; set; }

        public SubCategoryDto() { }
        public SubCategoryDto(int id,string name,int categoryId,CategoryDto cs) { 
            Id = id;
            Name = name;    
            CategoryId = categoryId;
            Category = cs;
        }
        public SubCategoryDto(int id, string name, int categoryId, Category cs)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Category = new CategoryDto(cs.Id,cs.Name);
        }
        public SubCategoryDto(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            
        }
    }
}
