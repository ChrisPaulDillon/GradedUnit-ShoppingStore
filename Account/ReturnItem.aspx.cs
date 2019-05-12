using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class ReturnItem : System.Web.UI.Page
{
    Order viewedOrder;
    OrderLine viewedOrderLine;
    Customer customerMember;
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        string orderLineId = Convert.ToString(Request.QueryString["OrderLineId"]);

        //If the user logged in is a customer and there is a valid orderLineId
        if ((string)Session["UserType"] == "Customer" && orderLineId != null)
        {
            viewedOrder = (Order)Session["ViewedOrder"]; 
            viewedOrderLine = viewedOrder.GetOrderLine(orderLineId); 
            customerMember = (Customer)Session["customerMember"];
            myShop = (Shop)Session["myShop"];
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Gets the variables from the users input
        string returnId = Guid.NewGuid().ToString();
        string productId = viewedOrderLine.Product.ProductId;
        string reason = txtReason.Text;
        string condition = ddlCondition.SelectedValue;
        string username = customerMember.Username;

        ProductReturn aProductReturn = new ProductReturn(returnId, productId, viewedOrder.OrderId, viewedOrderLine.OrderLineId, reason, condition, username);

        myShop.addProductReturn(aProductReturn);

        //Sends a success message to the MyOrders page
        string message = "Product has been requested to be returned";
        Session.Add("ProductReturned", message);
        Response.Redirect("~/Account/MyOrders.aspx");
    }
}