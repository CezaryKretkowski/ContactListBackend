using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class UserLoginDto
    {

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

    }
}
