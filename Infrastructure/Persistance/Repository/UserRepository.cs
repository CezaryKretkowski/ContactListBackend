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
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _dbContext;
        public UserRepository(ApiDbContext dbContext) {
            _dbContext = dbContext;
        }
        public User Add(User user)
        {
            user.Id = Guid.NewGuid();
            user.SubCategory = _dbContext.SubCategories.FirstOrDefault(c => c.Id == user.SubCategoryId);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            _dbContext?.Users.Remove(user);
            _dbContext.SaveChanges();
            return user;
        }

        public List<User> FindAll()
        {
            List<User> users = _dbContext.Users.ToList();
            foreach (var i in users) {
                var subCateogy = _dbContext.SubCategories.FirstOrDefault(n => n.Id == i.SubCategoryId);
                if (subCateogy != null) {
                    i.SubCategory = subCateogy;
                    i.SubCategory.Category = _dbContext.Categories.FirstOrDefault(n => n.Id == i.SubCategory.CategoryId); 
                }
            }
            return users;
        }

        public User GetByEmail(string email)
        {
            User user = _dbContext.Users.FirstOrDefault(i => i.Email.Equals(email));
            if (user == null) { return null; }
            user.SubCategory = _dbContext.SubCategories.FirstOrDefault(n => n.Id == user.SubCategoryId);

            return user;
        }

        public User GetById(Guid id)
        {
            User user = _dbContext.Users.FirstOrDefault(i => i.Id.Equals(id));
            if (user == null) { return null;  }
            user.SubCategory = _dbContext.SubCategories.FirstOrDefault(n => n.Id == user.SubCategoryId);

            return user;
           
        }

        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
