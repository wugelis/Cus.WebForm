using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public interface IProductsRepository
    {
        //在這裡定義你的介面
        #region ProductService
        /// <summary>
        /// 使用 ProductID 取得 ProductPrice.
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        object GetProductPriceByProductID(int ProductID);
        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <returns></returns>
        IEnumerable<Products> GetProducts();
        #endregion
    }
}

