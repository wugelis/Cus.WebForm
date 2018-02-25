using Cus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Models.Interface
{
    public interface IEmployeesRepository
    {
        //在這裡定義你的介面
        #region EmployeeService
        /// <summary>
        /// 取得產品負責人員工清單
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employees> GetEmployees();
        #endregion
    }
}

