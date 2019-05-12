using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Account_Register : System.Web.UI.Page
{
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customerMember"] == null) //if the user is not logged in
        {
            //If there is no shop session, create one
            if (Session["myShop"] == null)
            {
                myShop = new Shop();
                Session.Add("myShop", myShop);
            }
            else
            {
                myShop = (Shop)Session["myShop"];
            }
        }
        else
        {
            Response.Redirect("~/Account/MyAccount.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string userRegister = txtUser.Text;
        string passRegister = txtPass.Text;
        string confPass = txtConfPass.Text;
        string emailRegister = txtEmail.Text;
        
        //If there is no error returned, create the customer
        if (myShop.checkCredientials(userRegister, passRegister, confPass, emailRegister) != "")
        {
            lblRegisterError.Text = myShop.checkCredientials(userRegister, passRegister, confPass, emailRegister);
        }
        else
        {
            Customer customerMember = new Customer(userRegister.ToLower(), passRegister, emailRegister.ToLower());
            myShop.addCustomer(customerMember);
            Order cartOrder = new Order(Guid.NewGuid().ToString(), customerMember.Username);
            customerMember.CartOrder = cartOrder;
            customerMember.sendSignUpMail();
            string type = "Customer";
            Session.Add("UserType", type);
            Session.Add("customerMember", customerMember);
            Response.Redirect("~/Default.aspx");
        }
    }
}