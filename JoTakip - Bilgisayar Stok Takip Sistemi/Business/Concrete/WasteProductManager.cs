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
    public class WasteProductManager : IWasteProductService
    {
        IWasteProductDal wasteProductDal;

        public WasteProductManager(IWasteProductDal wasteProductDal)
        {
            this.wasteProductDal = wasteProductDal;
        }

        public void Add(Product product)
        {
            WasteProduct wasteProduct = new WasteProduct { Name = product.Name, Date = DateTime.Now.ToString("dd/MM/yyyy"), AssignedByDate = product.AssignedByDate, AssignedById = product.AssignedById, Id = product.Id };
            wasteProductDal.Add(wasteProduct);
        }

        public List<WasteProduct> GetList()
        {
            return wasteProductDal.GetList();
        }
    }
}
