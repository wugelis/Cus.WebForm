using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cus.Models.Entities
{
	public class Products
	{
		public int ProductID {get; set;}
		public string ProductName {get; set;}
		public int SupplierID {get; set;}
		public int CategoryID {get; set;}
		public string QuantityPerUnit {get; set;}
		public decimal UnitPrice {get; set;}
		public object UnitsInStock {get; set;}
		public object UnitsOnOrder {get; set;}
		public object ReorderLevel {get; set;}
		public object Discontinued {get; set;}
	}

}
