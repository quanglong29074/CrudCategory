using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudCategory
{
    public class CategoryDb : DbContext
    {
        public CategoryDb(DbContextOptions<CategoryDb> options) : base(options) { }
        public DbSet<Category> Categorys => Set<Category>();
    }
}
