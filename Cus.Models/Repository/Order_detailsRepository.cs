using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public class Order_detailsRepository : IOrder_detailsRepository
    {
        private IUnitOfWork _uow;

        public Order_detailsRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /* 透過 IUnitOfWork 取得資料的撰寫範例
        public IEnumerable<Order_details> GetCustomerList()
        {
            return _uow.Repository<Order_details>().GetCustomerList();
        }
        */
    }
}

