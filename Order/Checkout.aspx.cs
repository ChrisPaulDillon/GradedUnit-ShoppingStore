using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Order_Checkout : System.Web.UI.Page
{
    Customer customerMember;
    Shop myShop;
    decimal shippingPrice;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks if the user is a customer and currently has an order in process
        if ((string)Session["UserType"] == "Customer" && Session["OrderInProcess"] != null)
        {
            myShop = (Shop)Session["myShop"];
            customerMember = (Customer)Session["customerMember"];

            //If the user has not placed his/her order and has tried to access another page
            if (Session["OrderErrorMessage"] != null) 
            {
                lblWarning.Visible = true;
                lblWarning.Text = Convert.ToString(Session["OrderErrorMessage"]); //Displays error message
                Session["OrderErrorMessage"] = null;
            }

            lblTotal.Text = "Total: " + String.Format("{0:c}", customerMember.calcCartTotal()); //Gets cart total
            gvDisplayOrder.DataSource = customerMember.CartOrder.OrderLines;
            gvDisplayOrder.DataBind();
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
        
    protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Recalculates the total based on the shipping option
        if (rdbType.SelectedValue == "NextDay")
        {
            shippingPrice = 3.00M; 
            lblTotal.Text = "Total: " + String.Format("{0:c}", customerMember.calcCartTotal(shippingPrice));
        }

        if (rdbType.SelectedValue == "Standard")
        {
            shippingPrice = 0.00M;
            lblTotal.Text = "Total: " + String.Format("{0:c}", customerMember.calcCartTotal(shippingPrice));
        }
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {
        if (rdbType.SelectedValue == "NextDay")
        {
            customerMember.CartOrder.ShippingPrice = 3.00M;
        }
        if (rdbType.SelectedValue == "Standard")
        {
            customerMember.CartOrder.ShippingPrice = 0.00M;
        }

        customerMember.CartOrder.Total = customerMember.calcCartTotal(shippingPrice);
        customerMember.CartOrder.OrderDate = Convert.ToString(DateTime.Now);

        customerMember.addOrder();
        myShop.updateStock(customerMember.CartOrder.OrderLines);
        customerMember.sendOrderConfirmationEmail(customerMember.CartOrder.Total);
        customerMember.sendSmsOrderConfirmation(customerMember.CartOrder.Total);  
        customerMember.paypalCheckout();
        Response.Write(customerMember.paypalCheckout());//Post the form to PayPal
        this.PayPalPostScript(Page);
        customerMember.emptyUserCart();
        Session["OrderInProcess"] = null; //Order is no longer in process
    }

    private void PayPalPostScript(System.Web.UI.Page Page)
    {
        //This registers Javascript to the page which is used to post the PayPal Form details
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var ctlForm = document.getElementById('frmPP');");
        strScript.Append("ctlForm.submit();");
        strScript.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "PPSubmit", strScript.ToString());
    }

    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Session["OrderInProcess"] = null; //Order is no longer in process
        Response.Redirect("~/Default.aspx");
    }
}