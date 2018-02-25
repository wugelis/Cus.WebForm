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
    public interface IDbContextFactory
    {
        //請將下面的 MyDALClass 類別 置換成您實際的 DAL 類別
        DalCusOrders GetDbContext();
    }
}
