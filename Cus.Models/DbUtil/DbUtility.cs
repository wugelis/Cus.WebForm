using GelisFrameworks.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.DbUtil
{
    /// <summary>
    /// 提供與資料相關的附加功能. Use Gelis DAL Framework.
    /// </summary>
    public class DbUtility
    {
        #region Gelis DAL Framework
        private static MSSQLObject _MSSql = null;
        public static MSSQLObject DataUtil
        {
            get
            {
                if (_MSSql == null)
                    _MSSql = new MSSQLObject(new GelisFrameworks.Data.DAL.DataAccess());
                return _MSSql;
            }
        }
        #endregion
    }
}
