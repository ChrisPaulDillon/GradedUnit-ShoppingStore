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

public partial class Account_MyAccount : System.Web.UI.Page
{
    Customer customerMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks if the user logged in is a customer
        if ((string)Session["UserType"] == "Customer")
        {
            customerMember = (Customer)Session["customerMember"];
            //Displays a welcome message mentioning the users name
            lblWelcomeUser.Text = "You are currently signed in as " + customerMember.Username;
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
    protected void lbDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/MyDetails.aspx");
    }

    protected void lbOrders_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/MyOrders.aspx");
    }
}