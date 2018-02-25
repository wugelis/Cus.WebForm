using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public class ProductsRepository : IProductsRepository
    {
        private IUnitOfWork _uow;

        public ProductsRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /* 透過 IUnitOfWork 取得資料的撰寫範例
        public IEnumerable<Products> GetCustomerList()
        {
            return _uow.Repository<Products>().GetCustomerList();
        }
        */

        public object GetProductPriceByProductID(int ProductID)
        {
            return _uow.Repository<Products>().GetProductPriceByProductID(ProductID);
        }

        public IEnumerable<Products> GetProducts()
        {
            return _uow.Repository<Products>().GetProducts();
        }
    }
}

