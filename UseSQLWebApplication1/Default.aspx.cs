using Cus.Services.Interface;
//using Cus.DataAccess.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Cus.WebForm.Models;

namespace Cus.WebForm
{
    public partial class Default : BaseForm
    {
        public ICustomersService CustomerService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CreateList();
            }
        }

        private void CreateList()
        {
            //DalCusOrders DalCus = new DalCusOrders();
            ddlCusContacts.DataSource = CustomerService.GetCustomerList();
            ddlCusContacts.DataValueField = "CustomerID";
            ddlCusContacts.DataTextField = "ContactName";
            ddlCusContacts.DataBind();
        }

        protected void btnFindOrderByCus_Click(object sender, EventArgs e)
        {
            GetOrderDataByCus(ddlCusContacts.SelectedValue);
        }

        private void GetOrderDataByCus(string CusID)
        {
            //DalCusOrders DalCus = new DalCusOrders();
            gvOrderDetails.DataSource = CustomerService.GetByCusID(CusID);
            gvOrderDetails.DataBind();
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("AddOrder.aspx?customerid={0}", ddlCusContacts.SelectedValue));
        }
    }
}