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

public partial class Manage_Products_EditProduct : System.Web.UI.Page
{
    Shop myShop;
    Product editedProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        string productId = Convert.ToString(Request.QueryString["ProductId"]);

        //Checks to see if an admin/stock manager is logged in and there productId is actually valid
        if ((String)Session["UserType"] == "Administrator" || (String)Session["UserType"] == "Stock Manager" && productId != null)
        {
            myShop = (Shop)Session["myShop"];
            
            editedProduct = myShop.GetProduct(productId); //Gets the Product object from the id

            //Displays the product being edited current information
            lblName.Text = editedProduct.ProductName;
            lblDescription.Text = editedProduct.Description;
            lblPrice.Text = Convert.ToString(editedProduct.UnitPrice);
            lblQuantityHeld.Text = Convert.ToString(editedProduct.QuantityHeld);
            lblReorderLevel.Text = Convert.ToString(editedProduct.ReorderLevel);
            lblReorderQuantity.Text = Convert.ToString(editedProduct.ReorderQuantity);
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        } 
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //Gets the textbox inputs
            string name = txtName.Text;
            string desc = txtDescription.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int quantityHeld = Convert.ToInt32(txtQuantityHeld.Text);
            int reorderLevel = Convert.ToInt32(txtReorderLevel.Text);
            int reorderQuantity = Convert.ToInt32(txtReorderQuantity.Text);
            string imgPath = editedProduct.ImgPath;

            //Checks if the textboxes are empty or 0 before adding the new value
            editedProduct.checkDetails(name, desc, price, quantityHeld, reorderLevel, reorderQuantity);
            myShop.updateProduct(editedProduct);

            Response.Redirect("StockManagement.aspx");
        }
        catch
        {
            //Used to catch if the user has attempted to input anything invalid
            lblMessage.Visible = true;
            lblMessage.Text = "Invalid input within the textboxes!";
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Products/StockManagement.aspx");
    }
}