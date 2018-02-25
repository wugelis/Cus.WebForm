using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public class ShippersRepository : IShippersRepository
    {
        private IUnitOfWork _uow;

        public ShippersRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /* 透過 IUnitOfWork 取得資料的撰寫範例
        public IEnumerable<Shippers> GetCustomerList()
        {
            return _uow.Repository<Shippers>().GetCustomerList();
        }
        */

        public IEnumerable<Shippers> GetShippers()
        {
            return _uow.Repository<Shippers>().GetShippers();
        }
    }
}

