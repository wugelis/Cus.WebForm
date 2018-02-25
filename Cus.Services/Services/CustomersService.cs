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
    public class CustomersService: ICustomersService
    {
        
        private ICustomersRepository _Customers = null;

        public CustomersService(ICustomersRepository Customers)
        {
            _Customers = Customers;
        }
        

        //這裡實作的程式碼請叫用對應的 Repository ，並將資料轉換為讓可讓 (前端/Presentation/View) 所使用

        /// <summary>
        /// 取得特定客戶的所有訂單
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        public IEnumerable<CusOrderViewModel> GetByCusID(string CusID)
        {
            var result = from order in _Customers.GetByCusID(CusID)
                         select new CusOrderViewModel()
                         {
                             CustomerID = order.CustomerID,
                             OrderID = order.OrderID,
                             ContactName = order.ContactName,
                             City = order.City,
                             OrderDate = order.OrderDate,
                             ProductID = order.ProductID,
                             ProductName = order.ProductName,
                             UnitPrice = order.UnitPrice
                         };

            return result;
        }
        /// <summary>
        /// 取得所有的 Customer, ContactName 的連絡資訊.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerViewModel> GetCustomerList()
        {
            var result = from customers in _Customers.GetCustomerList()
                         select new CustomerViewModel()
                         {
                             CustomerID = customers.CustomerID,
                             ContactTitle = customers.ContactTitle,
                             ContactName = customers.ContactName,
                             CompanyName = customers.CompanyName,
                             City = customers.City,
                             Address = customers.Address,
                             Country = customers.Country,
                             Fax = customers.Fax,
                             Phone = customers.Phone,
                             PostalCode = customers.PostalCode,
                             Region = customers.Region
                         };
            return result;

        }
        /// <summary>
        /// 使用客戶代碼取得客戶的聯絡人名稱
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public object GetCustomerByCustomerID(string CustomerId)
        {
            return _Customers.GetCustomerByCustomerID(CustomerId);
        }
    }
}

