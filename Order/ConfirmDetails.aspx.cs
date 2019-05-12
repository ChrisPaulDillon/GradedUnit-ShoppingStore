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

public partial class Order_ConfirmDetails : System.Web.UI.Page
{
    Customer customerMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["UserType"] == "Customer") //User must be logged in and cart must be valid
        {
            customerMember = (Customer)Session["customerMember"];

            if (customerMember.checkMissingDetails())
            {
                string incompleteShippingInfo = "Please fill in all Shipping Information before continuing:";
                Session.Add("IncompleteShippingInfo", incompleteShippingInfo);
                Response.Redirect("~/Account/MyDetails.aspx");
            }
            else
            {
                lblFName.Text = customerMember.FirstName;
                lblLName.Text = customerMember.LastName;
                lblStreet.Text = customerMember.Street;
                lblTown.Text = customerMember.Town;
                lblPostcode.Text = customerMember.Postcode;
                lblPhoneNo.Text = customerMember.PhoneNo;
                lblEmail.Text = customerMember.Email;
            }

        }
        else
        {
            Response.Redirect("~/Account/Login.aspx"); //if no cart exists
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Session.Add("OrderInProcess", true);
        Response.Redirect("~/Order/Checkout.aspx");
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/MyDetails.aspx");
    }
}