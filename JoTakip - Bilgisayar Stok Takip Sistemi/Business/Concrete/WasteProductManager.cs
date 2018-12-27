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

        public void Add(WasteProduct product)
        {
            wasteProductDal.Add(product);
        }

        public List<WasteProduct> GetList()
        {
            return wasteProductDal.GetList();
        }
    }
}
