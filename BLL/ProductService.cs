using DAL;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo;

        public ProductService(IProductRepository productrepo)
        {
            _productRepo = productrepo;
        }

        public void Create(Product product)
        {
            _productRepo.Create(product);
        }

        public Product GetById(int? id)
        {
            return _productRepo.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }
    }
}
