using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            IWarehouseService warehouse = new WarehouseManager(productDal);
            warehouse.GetProducts().Single(x => x.Id == product.Id).Count -= 1;

            product.Count = 1;

            if (warehouse.GetProducts().Single(x => x.Id == product.Id).Count > 0)
            {
                product.AssignedById = personal.Id;
                productDal.Update(product);
            }
            else
            {
                productDal.Delete(product);
            }
        }

        public void BuyProduct(Product product)
        {
            IWarehouseService warehouse = new WarehouseManager(productDal);
            warehouse.AddProduct(product);
        }
    }
}
