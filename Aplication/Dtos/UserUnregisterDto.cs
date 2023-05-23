using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class UserUnregisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? SubCategoryId { get; set; }
        public SubCategoryDto SubCategory { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public DateOnly BirthDayDate { get; set; }
    }
}
