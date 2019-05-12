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

public partial class Manage_Users_AddUser : System.Web.UI.Page
{
    Shop myShop;
    string typeOfMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        typeOfMember = Convert.ToString(Request.QueryString["Type"]);

        //Checks to see if administrator is logged in
        if ((string)Session["UserType"] == "Administrator" && typeOfMember != null) 
        {
            myShop = (Shop)Session["myShop"];
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        if (typeOfMember == "Customer")
        {
            jobTitle.Visible = false;
        }
        else
        {
            jobTitle.Visible = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = true;

        try
        {
            string user = txtUsername.Text;
            string password = txtPassword.Text;
            string jobTitle = ddlJob.SelectedValue;
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string street = txtStreet.Text;
            string town = txtTown.Text;
            string postcode = txtPostcode.Text;
            string number = txtNumber.Text;
            string email = txtEmail.Text;

            if (typeOfMember == "Customer")
            {
                //Adds a new customer to the db
                Customer addedCustomer = new Customer(user, password, fName, lName, street, town, postcode, number, email);
                myShop.addCustomer(addedCustomer);
                lblMessage.Text = "Customer Added Successfully";
            }

            if (typeOfMember == "Staff")
            {
                Staff addedStaffMember = new Staff(user, password, jobTitle, fName, lName, street, town, postcode, number, email);
                myShop.addStaff(addedStaffMember);
                lblMessage.Text = "Staff Member Added Successfully";
            }
        }
        catch
        {
            //Used to catch if the user has attempted to input anything invalid
            lblMessage.Text = "Invalid input within the textboxes!";
        }

        //Resets textbox inputs
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtFName.Text = "";
        txtLName.Text = "";
        txtStreet.Text = "";
        txtTown.Text = "";
        txtPostcode.Text = "";
        txtNumber.Text = "";
        txtEmail.Text = "";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Users/UserManagement.aspx");
    }
}