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

public partial class MyOrders : System.Web.UI.Page
{
    Customer customerMember;
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks if the user logged in is a customer
        if ((string)Session["UserType"] == "Customer")
        {
            customerMember = (Customer)Session["customerMember"];
            myShop = (Shop)Session["myShop"];

            if (Session["ProductReturned"] != null) //if a product has been returned
            {
                //Displays a message stating the product has been requested to be returned
                lblReturnCancel.Visible = true;
                lblReturnCancel.Text = Convert.ToString(Session["ProductReturned"]);
                Session["ProductReturned"] = null;
            }

            if (Session["CancelMessage"] != null) //if an order has been returned
            {
                //Displays a message stating the order has been successfully cancelled
                lblReturnCancel.Visible = true;
                lblReturnCancel.Text = Convert.ToString(Session["CancelMessage"]);
                Session["CancelMessage"] = null;
            }

            //If an orderId is being taken from the address bar
            if (Request.QueryString["OrderId"] != null) 
            {
                string orderId = Convert.ToString(Request.QueryString["OrderId"]); //Gets the id from the address bar
                Order cancelledOrder = customerMember.GetOrder(orderId); //Gets the order linked to the id
                lblOrderMessage.Visible = true;
                string cancelMessage;

                //If the order has been placed before 48 hours
                if (cancelledOrder.isOrderCancelable() == true)
                {
                    customerMember.removeOrder(cancelledOrder);
                    cancelMessage = "Order successfully cancelled";
                    Session.Add("CancelMessage", cancelMessage);
                    
                }
                else
                {   //If the order has been placed after 48 hours
                    cancelMessage = "It has been over 48 hours since this order has been placed and is no longer cancellable";
                    Session.Add("CancelMessage", cancelMessage);
                }
                Response.Redirect("MyOrders.aspx");
            }

            /**
             * If the customers order is updated, it will display only that order.
             * If there is no order been updated, it will show all previous orders.
             * */

            Dictionary<string, Order> customerOrders;

            if (Session["CustomerWithOrder"] != null) //If an order has been marked as dispatched
            {
                lblOrderMessage.Visible = true;
                lblOrderMessage.Text = "One or more of your orders have been updated!";
                Order updatedOrder = (Order)Session["UpdatedOrder"];
                customerMember.GetOrder(updatedOrder.OrderId);
                
                customerOrders = new Dictionary<string, Order>();
                customerOrders.Add(updatedOrder.OrderId, updatedOrder); //Adds the updated order

                gvOrderList.DataSource = customerOrders;
                gvOrderList.DataBind(); 
                btnBack.Text = "View All";
            }
            else if (customerMember.CustomerOrders.Count > 0) //If there is no updated order
            {
                customerOrders = customerMember.CustomerOrders;
                gvOrderList.DataSource = customerOrders; //Displays all user orders
                gvOrderList.DataBind();
            }
            else
            {
                lblOrderMessage.Visible = true;
                lblOrderMessage.Text = "No orders found!";
            }
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Session["CustomerWithOrder"] != null) //If an order has been marked as dispatched
        {
            //Removes the sessions to allow all orders to be shown
            Session["UpdatedOrder"] = null;
            Session["CustomerWithOrder"] = null;
            Response.Redirect("~/Account/MyOrders.aspx");
        }
        else
        {   //If no order has been marked as dispatched, return to MyAccount as normal
            Response.Redirect("~/Account/MyAccount.aspx");
        }
    }
}