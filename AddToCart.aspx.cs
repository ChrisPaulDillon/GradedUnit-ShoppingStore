using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class AddToCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string productId = Convert.ToString(Request.QueryString["ProductId"]); 
        int quantity = Convert.ToInt32(Request.QueryString["Quantity"]); 

        if (quantity == 0)
        {
            //If no quantity is passed through, assume one
            quantity = 1;
        }

        if ((string)Session["UserType"] == "Customer") 
        {
            Shop myShop = (Shop)Session["myShop"];
            Customer customerMember = (Customer)Session["customerMember"];

            if (myShop.GetProduct(productId) != null) 
            {
                Product productBeingAdded = (Product)myShop.GetProduct(productId);

                if (productBeingAdded.QuantityHeld > 0) 
                {
                    customerMember.addToCart(productId, quantity); 
                }
                else 
                {
                    string outOfStock = "Out of stock in this product!";
                    //Session holding the error message to be passed to the products page
                    Session.Add("OutOfStock", outOfStock);
                    Response.Redirect("~/Products.aspx");
                }
            }
        }
        else
        {
            string loginMessage = "Please login before adding to cart!"; //No one is logged in
            //Session holds the message sent to the login page
            Session.Add("AddToCart", loginMessage);
            //Session holds the id of the product attempting to be added
            Session.Add("TempProduct", productId); 
            Response.Redirect("~/Account/Login.aspx");
        }
        Response.Redirect("ShoppingCart.aspx");
    }
}