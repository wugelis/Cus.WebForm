using Cus.Entities.Entities;
using Cus.Services.Interface;
using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Cus.WebForm.Models;

namespace Cus.WebForm
{
    public partial class AddOrder : BaseForm
    {
        public ICustomersService CustomerService { get; set; }
        public IProductsService ProductService { get; set; }
        public IEmployeesService EmployeeService { get; set; }
        public IOrdersService OrderService { get; set; }
        public IShippersService ShipperService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                GetHttpGetParam();
                CreateList();
            }
        }

        private void GetHttpGetParam()
        {
            if(Request["customerid"]!=null)
            {
                labContactID.Text = Request["customerid"];
                //DalCusOrders DalCus = new DalCusOrders();
                object customerName = CustomerService.GetCustomerByCustomerID(labContactID.Text);
                if(customerName!=null)
                {
                    txtContactName.Text = customerName.ToString();
                }
            }
        }

        private void CreateList()
        {
            //DalCusOrders DalCus = new DalCusOrders();
            var result = ProductService.GetProducts();
            ddlProducts.DataSource = result;
            ddlProducts.DataTextField = "ProductName";
            ddlProducts.DataValueField = "ProductID";
            ddlProducts.DataBind();
            labUnitPrice.Text = (from price in result.AsEnumerable() select new { UnitPrice = price.UnitPrice.ToString() }).FirstOrDefault().UnitPrice;
            //ddlProducts.Items.Insert(0, new ListItem("(請選擇)", "0"));
            ddlShippers.DataSource = ShipperService.GetShippers();
            ddlShippers.DataTextField = "CompanyName";
            ddlShippers.DataValueField = "ShipperID";
            ddlShippers.DataBind();
            ddlEmployee.DataSource = EmployeeService.GetEmployees();
            ddlEmployee.DataTextField = "FirstName";
            ddlEmployee.DataValueField = "EmployeeID";
            ddlEmployee.DataBind();
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            //DalCusOrders DalCus = new DalCusOrders();
            OrderViewModel order = new OrderViewModel()
            {
                CustomerID = labContactID.Text,
                EmployeeID = int.Parse(ddlEmployee.SelectedValue),
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = DateTime.Now.AddDays(2),
                Freight = 20,
                ShipName = ddlShippers.SelectedItem.Text,
                ORDER_DETAILS = new List<OrderDetailViewModel>(new OrderDetailViewModel[] {
                    new OrderDetailViewModel() {
                        ProductID = int.Parse(ddlProducts.SelectedValue),
                        Quantity = Int16.Parse(txtQuantity.Text),
                        UnitPrice = decimal.Parse(labUnitPrice.Text),
                        Discount = 1
                    }
                })
            };
            int result = OrderService.AddOrder(order);
            if(result>0)
            {
                Alert("新增成功！");
            }
            else
            {
                Alert("新增失敗！");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DalCusOrders DalCus = new DalCusOrders();
            object unitPrice = ProductService.GetProductPriceByProductID(int.Parse(ddlProducts.SelectedValue));
            if(unitPrice!=null)
            {
                labUnitPrice.Text = unitPrice.ToString();
            }
        }
    }
}