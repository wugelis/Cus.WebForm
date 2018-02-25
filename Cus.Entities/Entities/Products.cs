using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cus.Entities.Entities
{
	public class Products
	{
		public int ProductID {get; set;}
		public string ProductName {get; set;}
		public int SupplierID {get; set;}
		public int CategoryID {get; set;}
		public string QuantityPerUnit {get; set;}
		public decimal UnitPrice {get; set;}
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public short Discontinued { get; set; }
	}

}
