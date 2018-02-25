using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public class CustomersRepository : ICustomersRepository
    {
        private IUnitOfWork _uow;

        public CustomersRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /* 透過 IUnitOfWork 取得資料的撰寫範例
        public IEnumerable<Customers> GetCustomerList()
        {
            return _uow.Repository<Customers>().GetCustomerList();
        }
        */

        public IEnumerable<CusOrders> GetByCusID(string CusID)
        {
            return _uow.Repository<CusOrders>().GetByCusID(CusID);
        }

        public IEnumerable<Customers> GetCustomerList()
        {
            return _uow.Repository<Customers>().GetCustomerList();
        }

        public object GetCustomerByCustomerID(string CustomerId)
        {
            return _uow.Repository<CusOrders>().GetCustomerByCustomerID(CustomerId);
        }
    }
}

