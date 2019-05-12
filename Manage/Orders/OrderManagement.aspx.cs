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

public partial class Manage_Orders_OrderManagement : System.Web.UI.Page
{
    Shop myShop;
    Staff staffMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks if the user logged in is an admin
        if ((string)Session["UserType"] == "Administrator")
        {
            myShop = (Shop)Session["myShop"];
            staffMember = (Staff)Session["staffMember"];
            string orderId = Convert.ToString(Request.QueryString["OrderId"]); //Gets the orderId from the address bar

            if (orderId != null) //If an id is being passed through
            {
                Order updatedOrder = (Order)staffMember.GetOrder(orderId); //Gets order returned
                Customer customerWithOrder = (Customer)myShop.getCustomer(updatedOrder.Username); //Gets customer linked to order

                updatedOrder.ShippingStatus = "Dispatched"; //Assigns new shipping status
                updatedOrder.StaffUser = staffMember.Username; //Assigns staff member logged in to order

                customerWithOrder.updateOrder(updatedOrder); //Updates order in customer
                staffMember.getUnshippedOrders().Remove(updatedOrder.OrderId); //Removes the order from the unshipped orders dictionary

                Session.Add("UpdatedOrder", updatedOrder); //Adds the order to a Session to be forwarded to the login page
                Session.Add("CustomerWithOrder", customerWithOrder); //Adds the customer to a Session to be forwarded to the login page

                Response.Redirect("~/Manage/Orders/OrderManagement.aspx");
            }

            gvOrderList.Columns[4].Visible = false; //Removes option to approve
            gvOrderList.DataSource = staffMember.StaffOrders; //Shows all orders in the shop
            gvOrderList.DataBind();
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbType.SelectedValue == "All Orders")
        {
            gvOrderList.Columns[4].Visible = false; //Removes option to approve
            gvOrderList.DataSource = staffMember.StaffOrders; //Shows all orders in the shop
            gvOrderList.DataBind();
            lblMessage.Visible = false;
            
        }

        if (rdbType.SelectedValue == "Unshipped Orders")
        {
            gvOrderList.Columns[4].Visible = true; //Gives option to approve
            gvOrderList.DataSource = staffMember.getUnshippedOrders(); //Shows all orders not been marked as dispatched
            gvOrderList.DataBind();

            if (staffMember.getUnshippedOrders().Count < 1) //If there are no unshipped orders, display a message
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No orders currently needing dispatched";
            }
        }
    }
}