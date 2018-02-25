using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cus.DataAccess.Order
{
    public class Order_Details
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Int16 Discount { get; set; }
    }
}