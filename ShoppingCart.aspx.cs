using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class ShoppingCart : Page
{
    Customer customerMember;
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["UserType"] == "Customer") //if the user is logged in
        {
            //Redirects back to placing the order if not yet complete
            if (Session["OrderInProcess"] != null) 
            {
                string orderErrorMessage = "Please cancel or place your order before continuing!";
                Session.Add("OrderErrorMessage", orderErrorMessage);
                Response.Redirect("~/Order/Checkout.aspx");
            }
            customerMember = (Customer)Session["customerMember"];
            myShop = (Shop)Session["myShop"];

            //if the cart is empty, disable all options and display an error message
            if (customerMember.CartOrder.OrderLines.Count < 1)
            {
                lblWarning.Visible = true;
                lblWarning.Text = "Shopping Cart currently empty!";
                btnOrder.Visible = false;
                lblTotal.Visible = false;
                lblTotalText.Visible = false;
            }
            else
            {
                //Bind the customers shopping cart to the gridview
                gvCartList.DataSource = customerMember.CartOrder.OrderLines;
                gvCartList.DataBind();
            }

            //If there is an item being requested to remove
            if (Request.QueryString["OrderLineId"] != null) 
            {
                //Gets the individual item id to be removed from cart
                string removeId = Convert.ToString(Request.QueryString["OrderLineId"]);
                customerMember.removeCartItem(removeId);
                Response.Redirect("~/ShoppingCart.aspx");
            }

            decimal cartTotal = customerMember.calcCartTotal(); //Gets the cart total
            lblTotal.Text = String.Format("{0:c}", cartTotal); //Formats the cart total
        }
        else
        {
            Response.Redirect("Account/Login.aspx");
        }
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Order/ConfirmDetails.aspx");
    }
}