using Cus.DataAccess.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.DbContextFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class DbContextFactory : IDbContextFactory
    {
        private string _ConnectionString = string.Empty;
        public DbContextFactory(string connectionString)
        {
            this._ConnectionString = connectionString;
        }
        private DalCusOrders _dbContext;
        
        private DalCusOrders dbContext
        {
            get
            {
                if (this._dbContext == null)
                {
                    Type t = typeof(DalCusOrders);
                    this._dbContext = (DalCusOrders)Activator.CreateInstance(t);
                }
                return _dbContext;
            }
        }
        /// <summary>
        /// 請將 DalCusOrders 類別 置換成您實際的 DAL 類別
        /// </summary>
        /// <returns></returns>
        public DalCusOrders GetDbContext()
        {
            return this.dbContext;
        }
    }
    /// <summary>
    /// 請將 MyDAL 類別 Mark 掉，置換成您實際的 DAL 類別
    /// </summary>
    //public class MyDALClass : IDisposable
    //{
    //    public void Dispose()
    //    {
    //    }
    //}
}