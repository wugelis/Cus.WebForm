using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private IUnitOfWork _uow;

        public EmployeesRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /* 透過 IUnitOfWork 取得資料的撰寫範例
        public IEnumerable<Employees> GetCustomerList()
        {
            return _uow.Repository<Employees>().GetCustomerList();
        }
        */

        public IEnumerable<Employees> GetEmployees()
        {
            return _uow.Repository<Employees>().GetEmployees();
        }
    }
}

