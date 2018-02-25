using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Cus.DataAccess.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccess
    {
        //資料庫連接字串(使用 web.config來配置
        protected static string connectionString = "";
        protected SqlConnection rd_conn;

        public DataAccess()
        {
            connectionString = (new DBConn()).Connect();
        }
        public DataAccess(string AppSettingKey)
        {
            connectionString = (new DBConn()).Connect(AppSettingKey);
        }
        public DataAccess(DBConn dbConn)
        {
            connectionString = dbConn.ConnectionString;
        }
        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            else
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        /// <summary>
        /// 執行SQL Statement
        /// </summary>
        /// <param name="SQLString">SQL Statement</param>
        /// <returns></returns>
        public DataSet Query(string SQLString)
        {
            return Query(SQLString, null);
        }
        /// <summary>
        /// 執行SQL Statement (return 資料集)
        /// </summary>
        /// <param name="SQLString">Sql 敘述</param>
        /// <param name="cmdParms">SqlParameter</param>
        /// <returns></returns>
        public DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            return Query(SQLString, CommandType.Text, cmdParms);
        }
        /// <summary>
        /// 執行SQL Statement (return 資料集)
        /// </summary>
        /// <param name="SQLString">SQL Statement</param>
        /// <param name="cmdType">SqlParameter</param>
        /// <param name="cmdParms">參數值</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString, CommandType cmdType, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = cmdType;
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                        return ds;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed)
                            connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// 執行 SQL 敘述 (若不指定 Sql CommandType 則預設使用 CommandText)
        /// </summary>
        /// <param name="SQLString">SQL 敘述</param>
        /// <param name="cmdParms">SqlParameter</param>
        /// <returns></returns>
        public int ExecuteSQL(string SQLString, params SqlParameter[] cmdParms)
        {
            return ExecuteSQL(SQLString, CommandType.Text, cmdParms);
        }
        /// <summary>
        /// 執行 SQL 敘述
        /// </summary>
        /// <param name="SQLString">SQL 敘述</param>
        /// <param name="cmdType">Sql CommandType</param>
        /// <param name="cmdParms">SqlParameter</param>
        /// <returns></returns>
        public int ExecuteSQL(string SQLString, CommandType cmdType, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = cmdType;
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);

                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception("存取SQL Server發生錯誤. SysInfo=" + ex.Message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    connection.Dispose();
                    cmd.Dispose();
                }
            }
        }
        /// <summary>
        /// 取得單一值.
        /// Add by Gelis at 2011/3/22.
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public object GetExecuteScalar(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection CN = null;
            SqlCommand CMD = null;

            try
            {
                CN = new SqlConnection((new DBConn()).Connect());
                CMD = new SqlCommand();
                PrepareCommand(CMD, CN, null, SQLString, cmdParms);
                return CMD.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (CN.State != ConnectionState.Closed)
                {
                    CN.Close();
                    CN.Dispose();
                    CN = null;
                }
                if (CMD != null)
                {
                    CMD.Dispose();
                    CMD = null;
                }
            }
        }

        public object ExecuteScalar(
            SqlCommand cmd,
            string SQLString, 
            CommandType cmdType,
            ref SqlConnection connection,
            ref SqlTransaction tran,
            params SqlParameter[] cmdParms)
        {
            try
            {
                cmd.CommandType = cmdType;
                PrepareCommand(cmd, connection, tran, SQLString, cmdParms);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteSQL(
            SqlCommand cmd,
            string SQLString,
            CommandType cmdType,
            ref SqlConnection connection,
            ref SqlTransaction tran,
            params SqlParameter[] cmdParms)
        {
            cmd.CommandType = cmdType;
            PrepareCommand(cmd, connection, tran, SQLString, cmdParms);
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("存取SQL Server發生錯誤. SysInfo=" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
