using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public interface IOrdersRepository
    {
        //在這裡定義你的介面
        #region OrderService
        /// <summary>
        /// 新增一筆訂單資料.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        int AddOrder(Orders orders);
        #endregion
    }
}

