using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDBContext _Context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _Context = context;
        }

        public void Create(Category category)
        {
            _Context.Categories.Add(category);
            _Context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _Context.Categories.ToList();
        }
    }
}
