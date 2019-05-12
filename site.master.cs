using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class MasterPage : System.Web.UI.MasterPage
{
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Menu buttons for anon user

        lbLogout.Visible = false;
        lblLoggedIn.Visible = false;
        lbLogin.Visible = true;
        lbManage.Visible = false;
        lbUsers.Visible = false;
        lbOrderManagement.Visible = false;
        lbStockManagement.Visible = false;
        lbReturnManagement.Visible = false;

        //Initalising shop class
        if (Session["myShop"] == null)
        {
            myShop = new Shop();
            Session.Add("myShop", myShop);
        }
        else
        {
            myShop = (Shop)Session["myShop"];
        }

        //Menu buttons for any logged in user
        if ((string)Session["UserType"] == "Customer") 
        {
            lbLogout.Visible = true;
            lbLogin.Visible = false;
            lbManage.Visible = true;
            lblLoggedIn.Visible = true;
            Customer customerMember = (Customer)Session["customerMember"];
            lblLoggedIn.Text = "Welcome " + customerMember.Username;
        }

        //Menu buttons for administrator
        if ((string)Session["UserType"] == "Administrator") 
        {
            Staff staffMember = (Staff)Session["staffMember"];
            lblLoggedIn.Visible = true;
            lblLoggedIn.Text = "Welcome " + staffMember.Username;
            lbLogin.Visible = false;
            lbLogout.Visible = true;
            lbCart.Visible = false;
            lbContact.Visible = false;
            lbFindUs.Visible = false;
            lbManage.Visible = false;
            lbOrderManagement.Visible = true;
            lbStockManagement.Visible = true;
            lbProductList.Visible = false;
            lbUsers.Visible = true;
            lbReturnManagement.Visible = true;
        }

        //Menu buttons for a stock manager
        if ((string)Session["UserType"] == "Stock Manager")
        {
            Staff staffMember = (Staff)Session["staffMember"];
            lblLoggedIn.Visible = true;
            lblLoggedIn.Text = "Welcome " + staffMember.Username;
            lbLogin.Visible = false;
            lbLogout.Visible = true;
            lbCart.Visible = false;
            lbContact.Visible = false;
            lbFindUs.Visible = false;
            lbManage.Visible = false;
            lbStockManagement.Visible = true;
            lbProductList.Visible = false;
            lbUsers.Visible = false;
            lbReturnManagement.Visible = true;
        }
    }

    //Cancels all sessions relating to login upon click
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session["UserType"] = null; 
        Session["staffMember"] = null;
        Session["customerMember"] = null;
        Response.Redirect("~/Default.aspx");
    }

    protected void lbProductList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Products.aspx");
    }

    protected void lbHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void lbContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Contact.aspx");
    }

    protected void lbCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ShoppingCart.aspx");
    }

    protected void lbLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Login.aspx");
    }
    protected void lbManage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/MyAccount.aspx");
    }
    protected void lbOrderManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Orders/OrderManagement.aspx");
    }
    protected void lbStockManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Products/StockManagement.aspx");
    }
    protected void lbUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Users/UserManagement.aspx");
    }
    protected void lbFindUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FindUs.aspx");
    }
    protected void lbReturnManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Products/ReturnManagement.aspx");
    }
}
