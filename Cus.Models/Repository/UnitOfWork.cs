using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cus.Models.DbContextFactory;
using Cus.Models.Interface;
using Cus.Models.Repository;
using Cus.Models.Interface;
using Cus.DataAccess.Order;

namespace Cus.Models.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DalCusOrders _context { get; set; } //請將 MyDALClass 類別 置換成您實際的 DAL 類別
        private IDbContextFactory _factory;

        private Hashtable _repositories;
        private bool _disposed = false;

        public UnitOfWork(IDbContextFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentException("IDbContextFactory is null!.");
            }
            this._factory = factory;
            this._context = factory.GetDbContext();
        }
        /// <summary>
        /// 取得實作 IRepository 的物件.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            //判斷 Hashtable 中是否已經擁有符合的 type
            if (!_repositories.ContainsKey(type))
            {
                //建立需要的Repository
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(
                        repositoryType.MakeGenericType(typeof(T)),
                        _factory);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// 釋放物件
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
