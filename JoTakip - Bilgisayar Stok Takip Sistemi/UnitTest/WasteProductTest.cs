using System;
using Business;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class WasteProductTest
    {
        [TestMethod]
        public void MoveProductToWaste()
        {
            IWasteProductService wasteProductService = IocUtil.Resolve<IWasteProductService>();
            IWarehouseService warehouseService = IocUtil.Resolve<IWarehouseService>();

            Product product = warehouseService.GetProducts()[0];

            WasteProduct wasteProduct = new WasteProduct { Name = product.Name, Date = product.Date, AssignedByDate = product.AssignedByDate, AssignedById = product.AssignedById };

            warehouseService.DeleteProduct(product);
            wasteProductService.Add(wasteProduct);

            Assert.AreEqual(1, wasteProductService.GetList().Count);
        }
    }
}
