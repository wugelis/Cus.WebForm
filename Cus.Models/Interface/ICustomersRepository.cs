using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public interface ICustomersRepository
    {
        #region CustomerService
        /// <summary>
        /// 取得特定客戶的所有訂單.
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        IEnumerable<CusOrders> GetByCusID(string CusID);
        /// <summary>
        /// 取得所有的 Customer, ContactName 的連絡資訊.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customers> GetCustomerList();
        /// <summary>
        /// 使用客戶代碼取得客戶的聯絡人名稱
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        object GetCustomerByCustomerID(string CustomerId);
        #endregion
    }
}

