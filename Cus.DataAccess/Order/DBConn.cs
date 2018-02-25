using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Cus.DataAccess.Order
{
    public class DBConn
    {
        public string ConnectionString { get; set; }
        public DBConn() { Connect(); }
        public DBConn(string connectionString)
        {
            ConnectionString = connectionString;
        }
        /// <summary>
        /// 取得 ConnectionString 設定的連線字串 (預設使用 key="MSSQLDbConfig") 
        /// 注意：呼叫此方法會複寫屬性 ConnectionString 內的連線字串
        /// </summary>
        /// <returns></returns>
        public string Connect()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MSSQLDbConfig"].ConnectionString;
            return ConnectionString;
        }
        /// <summary>
        /// 取得 ConnectionString 設定的連線字串 (使用傳入的 key) 
        /// 注意：呼叫此方法會複寫屬性 ConnectionString 內的連線字串
        /// </summary>
        /// <param name="AppSettingKey"></param>
        /// <returns></returns>
        public string Connect(string AppSettingKey)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[AppSettingKey].ConnectionString;
            return ConnectionString;
        }
    }
}
