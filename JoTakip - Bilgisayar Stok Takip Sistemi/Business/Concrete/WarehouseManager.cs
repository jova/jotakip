using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        private IProductDal productDal;

        public WarehouseManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            this.productDal.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            productDal.Delete(product);
        }

        public List<Product> GetProducts()
        {
            return productDal.GetList();
        }
    }
}
