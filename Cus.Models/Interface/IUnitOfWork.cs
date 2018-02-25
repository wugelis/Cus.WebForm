using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        void Dispose();
        IRepository<T> Repository<T>() where T : class;
    }
}
