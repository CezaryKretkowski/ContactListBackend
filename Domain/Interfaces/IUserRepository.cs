using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        List<User> FindAll();
        User Add(User user);
        User Update(User user);
        User Delete(User user);
        User GetByEmail(string email);
    }
}
