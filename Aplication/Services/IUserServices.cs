using Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public interface IUserServices
    {
        IEnumerable<UserDto> GetAll();
        IEnumerable<UserUnregisterDto> GetAllUnregister();
        UserDto GetById(Guid id);

        UserRegisterDto Add(UserRegisterDto userDto);
        UserDto Update(UserDto userDto);
        void Delete(Guid id);
        bool IsUserExist(string email);

        UserDto GetUserByEmail(string s);
    }
}
