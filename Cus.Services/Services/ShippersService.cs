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
    public class ShippersService: IShippersService
    {
        
        private IShippersRepository _Shippers = null;

        public ShippersService(IShippersRepository Shippers)
        {
            _Shippers = Shippers;
        }
        

        //這裡實作的程式碼請叫用對應的 Repository ，並將資料轉換為讓可讓 (前端/Presentation/View) 所使用

        /// <summary>
        /// 取得貨運清單
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShipperViewModel> GetShippers()
        {
            var result = from shipper in _Shippers.GetShippers()
                         select new ShipperViewModel()
                         {
                             ShipperID = shipper.ShipperID,
                             CompanyName = shipper.CompanyName,
                             Phone = shipper.Phone
                         };

            return result;
        }
    }
}

