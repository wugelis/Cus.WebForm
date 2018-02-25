//using Cus.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cus.ViewModels
{
    /// <summary>
    /// 新增訂單資料的ViewModel
    /// </summary>
    public class AddOrderViewModel
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public IEnumerable<CustomerViewModel> CustomerList { get; set; }
        public int ProductID { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }
        public int EmployeeID { get; set; }
        public IEnumerable<EmployeeViewModel> EmployeeList { get; set; }
        public string City { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public int ShipperID { get; set; }
        public IEnumerable<ShipperViewModel> ShipperList { get; set; }
        public string ShipperAddress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
