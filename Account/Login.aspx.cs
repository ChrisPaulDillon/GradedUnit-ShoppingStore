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

public partial class Account_Login : System.Web.UI.Page
{
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType"] == null) //If the user is not logged in
        {
            //Create a new shop object is the session does not exists, or transfer the Session to the local shop object
            if (Session["myShop"] == null)
            {
                myShop = new Shop();
                Session.Add("myShop", myShop);
            }
            else
            {
                myShop = (Shop)Session["myShop"];
            }

            //If the user attempted to add to cart
            if (Session["AddToCart"] != null) 
            {
                lblLoginError.Visible = true;
                lblLoginError.Text = (string)Session["AddToCart"]; //Shows error message
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx"); //If the user is already logged in
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string userLogin = txtUser.Text;
        string passLogin = txtPass.Text;

        if (ddlType.SelectedValue == "Customer")
        {
            if (myShop.customerLogin(userLogin.ToLower(), passLogin)) //if the user exists in db
            {
                //Gets customer object of user logging in
                Customer customerMember = myShop.getCustomer(userLogin.ToLower(), passLogin); 

                string userType = "Customer";
                Session.Add("UserType", userType); //Sets the type of user to customer
                Session.Add("customerMember", customerMember);

                //Loads orders upon login
                DataAccess dbAccess = new DataAccess();
                customerMember.CustomerOrders = dbAccess.loadUserOrders(customerMember.Username);

                if (customerMember.CartOrder == null)
                {
                    //If there is no shoppingcart, create a new one
                    Order cartOrder = new Order(Guid.NewGuid().ToString(), customerMember.Username);
                    customerMember.CartOrder = cartOrder;
                }

                //If a customers order has been marked as dispatched
                if (Session["CustomerWithOrder"] != null) 
                {
                    Customer tempCustomer = (Customer)(Session["CustomerWithOrder"]);
                    //If the customer matches with the customer logging in
                    if (customerMember.Username == tempCustomer.Username)
                    {
                        Response.Redirect("~/Account/MyOrders.aspx");
                    }
                }
                //If the customer tried to add to basket before logging in
                if (Session["AddToCart"] != null) 
                {
                    //Adds the requested product to cart
                    Response.Redirect("~/AddToCart.aspx?ProductId=" + Session["TempProduct"].ToString());
                    Session["AddToCart"] = null;
                }
                //Checks if order is currently still in process
                if (Session["OrderInProcess"] != null) 
                {
                    string warning = "Please cancel or place your order before continuing!";
                    Session.Add("WarningMessage", warning);
                    Response.Redirect("~/Order/Checkout.aspx");
                }
                else 
                {
                    Response.Redirect("~/Default.aspx"); 
                }
            }
            else
            {   //Sends an error message when the credientials aren't found in the directionary
                lblLoginError.Text = "Your username or password is incorrect"; 
            }

        }
        if (ddlType.SelectedValue == "Administrator")
        {
            if (myShop.staffLogin(userLogin.ToLower(), passLogin))
            {
                Staff adminMember = myShop.getStaff(userLogin.ToLower(), passLogin);

                if (adminMember.JobTitle == "Administrator")
                {
                    string type = "Administrator";

                    Session.Add("UserType", type); //Sets the type of user to administrator
                    Session.Add("staffMember", adminMember);

                    //Loads all orders upon login
                    DataAccess dbAccess = new DataAccess();
                    adminMember.StaffOrders = dbAccess.loadOrders();

                    //If there are orders needing shipped, automatically forward to order management
                    if (adminMember.getUnshippedOrders().Count > 0) 
                    {
                        Response.Redirect("~/Manage/Orders/OrderManagement.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {   //If the staff members login details are correct but does not match the job title
                    lblLoginError.Text = "Wrong type of staff member";
                }
            }
            else
            {   //Sends an error message when the credientials aren't found in the directionary
                lblLoginError.Text = "Your username or password is incorrect";
            }
        }

        if (ddlType.SelectedValue == "Stock Manager")
        {
            if (myShop.staffLogin(userLogin.ToLower(), passLogin))
            {
                Staff stockMember = myShop.getStaff(userLogin.ToLower(), passLogin);

                if (stockMember.JobTitle == "Stock Manager")
                {
                    string type = "Stock Manager";
                    Session.Add("UserType", type); //Sets the type of user to Stock Manager
                    Session.Add("staffMember", stockMember);

                    Response.Redirect("~/Default.aspx");

                }
                else
                {   //If the staff members login details are correct but does not match the job title
                    lblLoginError.Text = "Wrong type of staff member";
                }
            }
            else
            {   //Sends an error message when the credientials aren't found in the directionary
                lblLoginError.Text = "Your username or password is incorrect";
            }
        }
    }

    protected void lbRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Register.aspx");
    }
}