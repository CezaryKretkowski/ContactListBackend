using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistance.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Category> Categories {get;set;}
        public virtual DbSet<SubCategory> SubCategories {get;set;}
        public virtual DbSet<User> Users {get;set;}
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {
            Database.EnsureCreated();
        }

    }
}
