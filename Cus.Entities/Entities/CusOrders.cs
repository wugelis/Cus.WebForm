using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Entities.Entities
{
    public class CusOrders
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
