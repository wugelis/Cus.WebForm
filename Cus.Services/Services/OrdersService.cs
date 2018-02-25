using Cus.Entities.Entities;
using Cus.Models.Interface;
using Cus.Services.Interface;
using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Services.Services
{
    /// <summary>
    /// Services Layer
    /// </summary>
    public class OrdersService: IOrdersService
    {
        
        private IOrdersRepository _Orders = null;

        public OrdersService(IOrdersRepository Orders)
        {
            _Orders = Orders;
        }
        

        //這裡實作的程式碼請叫用對應的 Repository ，並將資料轉換為讓可讓 (前端/Presentation/View) 所使用

        /// <summary>
        /// 新增一筆訂單資料.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public int AddOrder(OrderViewModel orders)
        {
            Orders order = new Orders()
            {
                CustomerID = orders.CustomerID,
                EmployeeID = orders.EmployeeID,
                OrderID = orders.OrderID,
                Freight = orders.Freight,
                OrderDate = orders.OrderDate,
                RequiredDate = orders.RequiredDate,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipCountry = orders.ShipCountry,
                ShipName = orders.ShipName,
                ShippedDate = orders.ShippedDate,
                ShipPostalCode = orders.ShipPostalCode,
                ShipRegion = orders.ShipRegion,
                ShipVia = orders.ShipVia,
                ORDER_DETAILS = (from query in orders.ORDER_DETAILS
                                select new Order_details()
                                {
                                    ProductID = query.ProductID,
                                    Quantity = query.Quantity,
                                    OrderID = query.OrderID,
                                    Discount = query.Discount,
                                    UnitPrice = query.UnitPrice
                                }).ToList()
            };
            return _Orders.AddOrder(order);
        }
    }
}

