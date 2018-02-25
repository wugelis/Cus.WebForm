using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public class OrdersRepository : IOrdersRepository
    {
        private IUnitOfWork _uow;

        public OrdersRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /* 透過 IUnitOfWork 取得資料的撰寫範例
        public IEnumerable<Orders> GetCustomerList()
        {
            return _uow.Repository<Orders>().GetCustomerList();
        }
        */

        public int AddOrder(Orders orders)
        {
            return _uow.Repository<Orders>().AddOrder(orders);
        }
    }
}

