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
    public class ProductsService: IProductsService
    {
        
        private IProductsRepository _Products = null;

        public ProductsService(IProductsRepository Products)
        {
            _Products = Products;
        }
        

        //這裡實作的程式碼請叫用對應的 Repository ，並將資料轉換為讓可讓 (前端/Presentation/View) 所使用

        /// <summary>
        /// 使用 ProductID 取得 ProductPrice.
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public object GetProductPriceByProductID(int ProductID)
        {
            return _Products.GetProductPriceByProductID(ProductID);
        }
        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var result = from products in _Products.GetProducts()
                         select new ProductViewModel()
                         {
                             ProductID = products.ProductID,
                             CategoryID = products.CategoryID,
                             SupplierID = products.SupplierID,
                             ProductName = products.ProductName,
                             Discontinued = products.Discontinued,
                             QuantityPerUnit = products.QuantityPerUnit,
                             ReorderLevel = products.ReorderLevel,
                             UnitPrice = products.UnitPrice,
                             UnitsInStock = products.UnitsInStock,
                             UnitsOnOrder = products.UnitsOnOrder
                         };

            return result;
        }
    }
}

