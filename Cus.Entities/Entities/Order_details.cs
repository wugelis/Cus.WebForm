using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cus.Entities.Entities
{
	public class Order_details
	{
		public int OrderID {get; set;}
		public int ProductID {get; set;}
		public decimal UnitPrice {get; set;}
		public object Quantity {get; set;}
		public object Discount {get; set;}
	}

}
