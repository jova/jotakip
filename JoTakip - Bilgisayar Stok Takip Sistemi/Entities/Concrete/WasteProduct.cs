using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WasteProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssignedById { get; set; }
        public string Date { get; set; }
        public string AssignedByDate { get; set; }
    }
}
