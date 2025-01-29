using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context= context;
        }

        public void Create(Product product)
        {
             _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetById(int? id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}
