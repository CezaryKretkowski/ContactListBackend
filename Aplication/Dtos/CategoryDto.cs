using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDto() { }
        public CategoryDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
