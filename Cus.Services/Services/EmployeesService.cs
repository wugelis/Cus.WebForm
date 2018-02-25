using Cus.Models.Interface;
using Cus.Services.Interface;
using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Services.Services
{
    /// <summary>
    /// Services Layer
    /// </summary>
    public class EmployeesService: IEmployeesService
    {
        
        private IEmployeesRepository _Employees = null;

        public EmployeesService(IEmployeesRepository Employees)
        {
            _Employees = Employees;
        }
        

        //這裡實作的程式碼請叫用對應的 Repository ，並將資料轉換為讓可讓 (前端/Presentation/View) 所使用

        /// <summary>
        /// 取得產品負責人員工清單
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var result = from empoyee in _Employees.GetEmployees()
                         select new EmployeeViewModel()
                         {
                             EmployeeID = empoyee.EmployeeID,
                             FirstName = empoyee.FirstName,
                             LastName = empoyee.LastName,
                             Country = empoyee.Country,
                             City = empoyee.City,
                             BirthDate = empoyee.BirthDate,
                             Address = empoyee.Address,
                             HomePhone = empoyee.HomePhone,
                             Notes = empoyee.Notes,
                             PostalCode = empoyee.PostalCode,
                             Region = empoyee.Region,
                             Title = empoyee.Title,
                             TitleOfCourtesy = empoyee.TitleOfCourtesy
                         };

            return result;
        }
    }
}

