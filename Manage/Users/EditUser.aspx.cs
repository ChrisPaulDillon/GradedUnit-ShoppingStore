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

public partial class Manage_Users_EditUser : System.Web.UI.Page
{
    Shop myShop;
    Customer editedCustomer;
    Staff editedStaffMember;
    string typeOfMember;
    string username;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["UserType"] == "Administrator") //Checks to see if administrator is logged in
        {
            typeOfMember = Convert.ToString(Request.QueryString["Type"]);
            username = Convert.ToString(Request.QueryString["Username"]);
            myShop = (Shop)Session["myShop"];

            if (typeOfMember == "Customer")
            {
                editedCustomer = (Customer)myShop.getCustomer(username);
                lblUsername.Text = editedCustomer.Username;
                lblFName.Text = editedCustomer.FirstName;
                lblLName.Text = editedCustomer.LastName;
                lblStreet.Text = editedCustomer.Street;
                lblTown.Text = editedCustomer.Town;
                lblPostcode.Text = editedCustomer.Postcode;
                lblPhoneNo.Text = editedCustomer.PhoneNo;
                lblEmail.Text = editedCustomer.Email;
            }
            if (typeOfMember == "Staff")
            {
                editedStaffMember = (Staff)myShop.getStaff(username);
                lblUsername.Text = editedStaffMember.Username;
                lblFName.Text = editedStaffMember.FirstName;
                lblLName.Text = editedStaffMember.LastName;
                lblStreet.Text = editedStaffMember.Street;
                lblTown.Text = editedStaffMember.Town;
                lblPostcode.Text = editedStaffMember.Postcode;
                lblPhoneNo.Text = editedStaffMember.PhoneNo;
                lblEmail.Text = editedStaffMember.Email;
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string user = txtUsername.Text;
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string street = txtStreet.Text;
            string town = txtTown.Text;
            string postcode = txtPostcode.Text;
            string number = txtPhoneNo.Text;
            string email = txtEmail.Text;

            if (typeOfMember == "Customer")
            {
                editedCustomer.updateDetails(user, fName, lName, street, town, postcode, number, email);
                myShop.updateCustomerDetails(editedCustomer);
            }

            if (typeOfMember == "Staff")
            {
                editedStaffMember.updateDetails(user, fName, lName, street, town, postcode, number, email);
                myShop.updateStaffDetails(editedStaffMember);
            }
            Response.Redirect("UserManagement.aspx");
        }
        catch
        {
            //Used to catch if the user has attempted to input anything invalid
            lblMessage.Text = "Invalid input within the textboxes!";
        }
        //Resets textbox inputs
        txtUsername.Text = "";
        txtFName.Text = "";
        txtLName.Text = "";
        txtStreet.Text = "";
        txtTown.Text = "";
        txtPostcode.Text = "";
        txtPhoneNo.Text = "";
        txtEmail.Text = "";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Users/UserManagement.aspx");
    }
}