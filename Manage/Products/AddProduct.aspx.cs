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

public partial class AddProduct : Page
{
    Shop myShop;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if administrator/stock manager is logged in 
        if ((String)Session["UserType"] == "Administrator" || (String)Session["UserType"] == "Stock Manager")
        {
            myShop = (Shop)Session["myShop"];
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = true;

        try
        {
            //Gets the text input from each textbox
            string name = txtName.Text;
            string desc = txtDescription.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int quantityHeld = Convert.ToInt32(txtQuantityHeld.Text);
            int reorderLevel = Convert.ToInt32(txtReorderLevel.Text);
            int reorderQuantity = Convert.ToInt32(txtReorderQuantity.Text);

            Product productAdded = new Product(Guid.NewGuid().ToString(), name, desc, price, quantityHeld, reorderLevel, reorderQuantity);
            myShop.addProduct(productAdded);

            lblMessage.Text = "Product Added Successfully";

        }
        catch
        {
            //Used to catch if the user has attempted to input anything invalid 
            lblMessage.Text = "Invalid input within the textboxes!";
        }

        //Resets textboxes
        txtName.Text = "";
        txtDescription.Text = "";
        txtPrice.Text = "";
        txtQuantityHeld.Text = "";
        txtReorderLevel.Text = "";
        txtReorderQuantity.Text = "";
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Products/StockManagement.aspx");
    }
}