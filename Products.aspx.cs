using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Products : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Shop myShop;

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

        //Checks if a user has attempted to add an out of stock item
        if (Session["OutOfStock"] != null) 
        {
            lblWarning.Text = Convert.ToString(Session["OutOfStock"]); 
            Session["OutOfStock"] = null;
        }

        //Redirects back to placing the order if not yet complete
        if (Session["OrderInProcess"] != null) 
        {
            string checkOrderProgress = "Please cancel or place your order before continuing!";
            Session.Add("CheckOrderProgress", checkOrderProgress);
            Response.Redirect("~/Order/Checkout.aspx");
        }

        string input = txtSearch.Text;
        //If there is no input in the search box, display all products
        if (input == "") 
        {
            gvProducts.DataSource = myShop.ShopProducts;
        }
        else
        {
            gvProducts.DataSource = myShop.searchProducts(input);
        }
        gvProducts.DataBind();
    }
}