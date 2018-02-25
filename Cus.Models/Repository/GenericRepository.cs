using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cus.Models.Interface;
using Cus.Models.DbUtil;
using Cus.Models.DbContextFactory;
using Cus.DataAccess.Order;
using Cus.Entities.Entities;

namespace Cus.Models.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DalCusOrders _context { get; set; } //請將 MyDALClass 類別 置換成您實際的 DAL 類別
        private IDbContextFactory _factory;

        public GenericRepository(IDbContextFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentException("IDbContextFactory is null!.");
            }
            this._factory = factory;
            this._context = factory.GetDbContext();
        }
        /*
        /// <summary>
        /// 取回資料範例
        /// </summary>
        /// <returns></returns>
        public IEnumerable<> GetAllData()
        {
            return DbUtility.DataUtil.GetEnumerableByDataTable<>(_context.GetAllData());
        }
        */

        public IEnumerable<Entities.Entities.Shippers> GetShippers()
        {
            return DbUtility.DataUtil.GetEnumerableByDataTable<Shippers>(_context.GetShippers());
        }

        public object GetProductPriceByProductID(int ProductID)
        {
            return _context.GetProductPriceByProductID(ProductID);
        }

        public IEnumerable<Entities.Entities.Products> GetProducts()
        {
            return DbUtility.DataUtil.GetEnumerableByDataTable<Products>(_context.GetProducts());
        }

        public int AddOrder(Entities.Entities.Orders orders)
        {
            return _context.AddOrder(orders);
        }

        public IEnumerable<Entities.Entities.Employees> GetEmployees()
        {
            return DbUtility.DataUtil.GetEnumerableByDataTable<Employees>(_context.GetEmployees());
        }

        public IEnumerable<Entities.Entities.CusOrders> GetByCusID(string CusID)
        {
            return DbUtility.DataUtil.GetEnumerableByDataTable<CusOrders>(_context.GetByCusID(CusID));
        }

        public IEnumerable<Entities.Entities.Customers> GetCustomerList()
        {
            return DbUtility.DataUtil.GetEnumerableByDataTable<Customers>(_context.GetCustomerList());
        }

        public object GetCustomerByCustomerID(string CustomerId)
        {
            return _context.GetCustomerByCustomerID(CustomerId);
        }
    }
}
