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

public partial class Account_MyDetails : System.Web.UI.Page
{
    Shop myShop;
    Customer customerMember;
    Staff staffMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        //If the user has missing shipping info and has came from confirmdetails
        if (Session["IncompleteShippingInfo"] != null)
        {
            lblIncompleteInfo.Text = Session["incompleteShippingInfo"].ToString(); 
        }

        //If the user logged in is a customer, display all customer information
        if ((string)Session["UserType"] == "Customer")
        {
            customerMember = (Customer)Session["customerMember"];
            myShop = (Shop)Session["myShop"];
            lblFName.Text = customerMember.FirstName;
            lblLName.Text = customerMember.LastName;
            lblStreet.Text = customerMember.Street;
            lblTown.Text = customerMember.Town;
            lblPostcode.Text = customerMember.Postcode;
            lblNumber.Text = customerMember.PhoneNo;
            lblEmail.Text = customerMember.Email;
        }

        //If the user logged in is a staff mmember, display all staff information
        if ((string)Session["UserType"] == "Administrator" || (string)Session["UserType"] == "Stock Manager")
        {
            staffMember = (Staff)Session["staffMember"];
            myShop = (Shop)Session["myShop"];
            lblFName.Text = staffMember.FirstName;
            lblLName.Text = staffMember.LastName;
            lblStreet.Text = staffMember.Street;
            lblTown.Text = staffMember.Town;
            lblPostcode.Text = staffMember.Postcode;
            lblNumber.Text = staffMember.PhoneNo;
            lblEmail.Text = staffMember.Email;
        }

        //If no user is logged in prompt the user to login
        if (Session["UserType"] == null)
        {
            Response.Redirect("~/Account/Login.aspx");
        } 
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string userType = (string)Session["UserType"]; //Gets the type of user logged in

        //Updates the customer members details based on the users input
        if (userType == "Customer")
        {
            customerMember.updateDetails(txtFName.Text, txtLName.Text, txtStreet.Text, txtTown.Text, txtPostcode.Text, txtNumber.Text);
            myShop.updateCustomerDetails(customerMember);
        }

        //Updates the staff members details based on the users input
        if (userType == "Administrator" || userType == "Stock Manager")
        {
            staffMember.updateDetails(txtFName.Text, txtLName.Text, txtStreet.Text, txtTown.Text, txtPostcode.Text, txtNumber.Text);
            myShop.updateStaffDetails(staffMember);
        }

        //Checks if the user has came from the confirmdetails page and has missing shipping info
        if (Session["IncompleteShippingInfo"] != null)
        {
            //If all shipping info is still not filled out, remain on the same page and keep the Session
            if (customerMember.checkMissingDetails()) 
            {
                Response.Redirect("MyDetails.aspx");
            }
            else
            {  //All shipping info is filled out, proceed with order and remove the Session
                Session.Add("OrderInProcess", true); //Used to check if the order is currently taken place
                Session["IncompleteShippingInfo"] = null;
                Response.Redirect("~/Order/Checkout.aspx"); //Continue with order
            }
        }
        else
        {
            Response.Redirect("~/Account/MyDetails.aspx");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/MyAccount.aspx");
    }
}