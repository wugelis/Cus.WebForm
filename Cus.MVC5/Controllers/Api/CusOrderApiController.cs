using Cus.Services.Interface;
using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cus.MVC5.Controllers.Api
{
    public class CusOrderApiController : ApiController
    {
        private ICustomersService _customer = null;

        public CusOrderApiController(ICustomersService customer)
        {
            _customer = customer;
        }

        public IEnumerable<CusOrderViewModel> Get()
        {
            return _customer.GetByCusID(string.Empty);
        }

        public IEnumerable<CusOrderViewModel> Get(string id)
        {
            return _customer.GetByCusID(id);
        }
    }
}
