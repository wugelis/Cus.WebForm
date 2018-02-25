using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public interface IShippersRepository
    {
        //在這裡定義你的介面
        #region ShipperService
        /// <summary>
        /// 取得貨運清單
        /// </summary>
        /// <returns></returns>
        IEnumerable<Shippers> GetShippers();
        #endregion
    }
}

