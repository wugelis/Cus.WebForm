using Cus.Services.Interface;
using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cus.MVC5.Controllers
{
    public class CusController : Controller
    {
        private ICustomersService _customer = null;
        private IProductsService _product = null;
        private IOrdersService _order = null;
        private IShippersService _shipper = null;
        private IEmployeesService _employee = null;

        public CusController(
            ICustomersService customer,
            IProductsService product,
            IOrdersService order,
            IShippersService shipper,
            IEmployeesService employee)
        {
            _customer = customer;
            _product = product;
            _order = order;
            _shipper = shipper;
            _employee = employee;
        }

        // GET: Cus
        public ActionResult Index()
        {
            QueryViewModel queryView = new QueryViewModel()
            {
                CUS_Ordes = _customer.GetByCusID(string.Empty),
                CustomerList = _customer.GetCustomerList(),
                QUERY_PARAM = new QueryParam() { CustomerID = string.Empty}
            };
            return View(queryView);
        }

        [HttpPost]
        public ActionResult Index(QueryViewModel model)
        {
            QueryViewModel queryView = new QueryViewModel()
            {
                CUS_Ordes = _customer.GetByCusID(model.QUERY_PARAM.CustomerID),
                CustomerList = _customer.GetCustomerList(),
                QUERY_PARAM = new QueryParam() { CustomerID = model.QUERY_PARAM.CustomerID }
            };
            return View(queryView);
        }

        public ActionResult AddOrder()
        {
            AddOrderViewModel addOrder = GetAddOrderViewModel();
            return View(addOrder);
        }

        [HttpPost]
        public ActionResult AddOrder(AddOrderViewModel AddOrder)
        {
            OrderViewModel order = new OrderViewModel()
            {
                CustomerID = AddOrder.CustomerID,
                EmployeeID = AddOrder.EmployeeID,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = DateTime.Now.AddDays(2),
                Freight = 20,
                ShipName = _shipper.GetShippers().Where(c => c.ShipperID == AddOrder.ShipperID).FirstOrDefault().CompanyName,
                ORDER_DETAILS = new List<OrderDetailViewModel>(new OrderDetailViewModel[] {
                    new OrderDetailViewModel() {
                        ProductID = AddOrder.ProductID,
                        Quantity = AddOrder.Quantity,
                        UnitPrice = AddOrder.UnitPrice,
                        Discount = 1
                    }
                })
            };
            int result = _order.AddOrder(order);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            return View();
        }

        public ActionResult IndexAngularJS()
        {
            return View();
        }

        private AddOrderViewModel GetAddOrderViewModel()
        {
            AddOrderViewModel addOrder = new AddOrderViewModel()
            {
                CustomerList = _customer.GetCustomerList(),
                OrderDate = DateTime.Now,
                ProductList = _product.GetProducts(),
                EmployeeList = _employee.GetEmployees(),
                ShipperList = _shipper.GetShippers(),
                Quantity = 1
            };
            return addOrder;
        }
    }
}