using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cus.Services.Interface
{
    public interface ICustomersService
    {
        IEnumerable<CusOrderViewModel> GetByCusID(string CusID);
        IEnumerable<CustomerViewModel> GetCustomerList();
        object GetCustomerByCustomerID(string CustomerId);
    }
}

