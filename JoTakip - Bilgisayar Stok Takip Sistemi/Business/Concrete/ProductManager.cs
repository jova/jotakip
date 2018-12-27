using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal productDal;
        private IPersonalDal personalDal;

        public ProductManager(IProductDal productDal, IPersonalDal personalDal)
        {
            this.productDal = productDal;
            this.personalDal = personalDal;
        }

        public void AssignProduct(Personal personal, Product product)
        {
            product.AssignedById = personal.Id;
            product.AssignedByDate = DateTime.Now.ToString("dd/MM/yyyy");
            productDal.Update(product);
        }

        public void BuyProduct(Product product, int count)
        {
            IWarehouseService warehouse = new WarehouseManager(productDal);

            List<Product> products = new List<Product>();

            for (int i = 0; i < count; i++) products.Add(product);

            warehouse.AddProducts(products);
        }

        public void UnAssignProduct(Product product)
        {
            product.AssignedById = 0;
            productDal.Update(product);
        }
    }
}
