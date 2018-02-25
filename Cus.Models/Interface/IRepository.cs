using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    /// <summary>
    /// DAL: 共通的 Reposiroty 樣式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IShippersRepository,IProductsRepository,IOrdersRepository,IEmployeesRepository,ICustomersRepository
    {
    }
}

