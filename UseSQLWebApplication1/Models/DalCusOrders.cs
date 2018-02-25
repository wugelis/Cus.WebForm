using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cus.WebForm.Models.Data;

namespace Cus.WebForm.Models
{
    public class DalCusOrders
    {
        #region 取得所有的 Customer, ContactName 的連絡資訊.
        /// <summary>
        /// 取得所有的 Customer, ContactName 的連絡資訊.
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerList()
        {
            DataAccess dal = new DataAccess();
            string SqlStatement = 
                @"select DISTINCT C.CustomerID, C.ContactName from Customers C";
            return dal.Query(SqlStatement).Tables[0];
        }
        #endregion

        #region 使用客戶代碼取得客戶的聯絡人名稱
        /// <summary>
        /// 使用客戶代碼取得客戶的聯絡人名稱
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public object GetCustomerByCustomerID(string CustomerId)
        {
            DataAccess dal = new DataAccess();
            string SqlStatement =
                @"select TOP 1 C.ContactName from Customers C WHERE C.CustomerID=@CustomerID";
            SqlParameter[] SqlParames = new SqlParameter[] { new SqlParameter("@CustomerID", CustomerId) };
            return dal.GetExecuteScalar(SqlStatement, SqlParames);
        }
        #endregion

        #region 取得特定客戶的所有訂單.
        /// <summary>
        /// 取得特定客戶的所有訂單.
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        public DataTable GetByCusID(string CusID)
        {
            DataAccess dal = new DataAccess();
            string SqlStatement = @"SELECT          Customers.CustomerID, Customers.CompanyName, Customers.ContactName, Customers.City, 
                            [Order Details].OrderID, [Order Details].UnitPrice, Products.ProductID, Products.ProductName, Orders.OrderDate
FROM              Orders INNER JOIN
                            [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN
                            Products ON [Order Details].ProductID = Products.ProductID INNER JOIN
                            Customers ON Orders.CustomerID = Customers.CustomerID
WHERE          (Orders.CustomerID = @CustomerID)";

            SqlParameter[] SqlParames = new SqlParameter[] { 
                new SqlParameter("@CustomerID", CusID)
            };
            return dal.Query(SqlStatement, SqlParames).Tables[0];
        }
        #endregion

        #region 取得產品清單
        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <returns></returns>
        public DataTable GetProducts()
        {
            DataAccess dal = new DataAccess();
            string SqlStatement = @"select P.ProductID, P.ProductName, P.UnitPrice from Products P
ORDER by P.ProductName";
            return dal.Query(SqlStatement).Tables[0];
        }
        #endregion

        #region 取得貨運清單
        /// <summary>
        /// 取得貨運清單
        /// </summary>
        /// <returns></returns>
        public DataTable GetShippers()
        {
            DataAccess dal = new DataAccess();
            string SqlStatement = @"select S.ShipperID, S.CompanyName from [Shippers] S";
            return dal.Query(SqlStatement).Tables[0];
        }
        #endregion

        #region 取得產品金額 by 產品Id.
        /// <summary>
        /// 取得產品金額 by 產品Id.
        /// </summary>
        /// <param name="ProudctID"></param>
        /// <returns></returns>
        public object GetProductPriceByProductID(int ProductID)
        {
            DataAccess dal = new DataAccess();
            string SqlStatement = @"select P.UnitPrice from Products P
WHERE P.ProductID=@ProductID";
            return dal.GetExecuteScalar(SqlStatement, new SqlParameter[] {
                new SqlParameter("@ProductID", ProductID)
            });
        }
        #endregion

        #region 取得產品負責人員工清單
        /// <summary>
        /// 取得產品負責人員工清單
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployees()
        {
            DataAccess dal = new DataAccess();
            string SqlStatement = @"select E.EmployeeID, E.FirstName from Employees E";
            return dal.Query(SqlStatement).Tables[0];
        }
        #endregion

        #region 新增一筆訂單資料.
        /// <summary>
        /// 新增一筆訂單資料.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public int AddOrder(Orders orders)
        {
            string SqlOrder = @"INSERT INTO [Orders]
           ([CustomerID]
           ,[EmployeeID]
           ,[OrderDate]
           ,[RequiredDate]
           ,[ShippedDate]
           ,[Freight]
           ,[ShipName])
     VALUES
           (@CustomerID
           ,@EmployeeID
           ,@OrderDate
           ,@RequiredDate
           ,@ShippedDate
           ,@Freight
           ,@ShipName);select @@IDENTITY";

            string SqlOrderDetails = @"INSERT INTO [dbo].[Order Details]
           ([OrderID]
           ,[ProductID]
           ,[UnitPrice]
           ,[Quantity]
           ,[Discount])
     VALUES
           (@OrderID
           ,@ProductID
           ,@UnitPrice
           ,@Quantitys
           ,@Discount)";

            SqlConnection connection = new SqlConnection(new DBConn().ConnectionString);
            SqlTransaction tran = null;
            try
            {
                DataAccess dal = new DataAccess();
                int result = 0;
                connection.Open();
                tran = connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(SqlOrder, connection, tran);
                SqlParameter[] ParamOrder = new SqlParameter[] { 
                    new SqlParameter("@CustomerID", orders.CustomerID),
                    new SqlParameter("@EmployeeID", orders.EmployeeID),
                    new SqlParameter("@OrderDate", orders.OrderDate),
                    new SqlParameter("@RequiredDate", orders.RequiredDate),
                    new SqlParameter("@ShippedDate", orders.ShippedDate),
                    new SqlParameter("@Freight", orders.Freight),
                    new SqlParameter("@ShipName", orders.ShipName)
                };
                object identity = dal.ExecuteScalar(cmd, SqlOrder, CommandType.Text, ref connection, ref tran, ParamOrder);
                Order_Details order_detail = orders.ORDER_DETAILS.FirstOrDefault();
                if(order_detail!=null)
                {
                    SqlParameter[] ParamOrderDetails = new SqlParameter[] { 
                        new SqlParameter("@OrderID", identity),
                        new SqlParameter("@ProductID", order_detail.ProductID),
                        new SqlParameter("@UnitPrice", order_detail.UnitPrice),
                        new SqlParameter("@Quantitys", order_detail.Quantity),
                        new SqlParameter("@Discount", order_detail.Discount)
                    };
                    result += dal.ExecuteSQL(cmd, SqlOrderDetails, CommandType.Text, ref connection, ref tran, ParamOrderDetails);
                }
                
                tran.Commit();
                return result;
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                connection.Dispose();
            }
        }
        #endregion
    }
}