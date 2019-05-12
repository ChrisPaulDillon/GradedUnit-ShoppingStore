using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class ProductDetails : System.Web.UI.Page
{
    string productId; 

    protected void Page_Load(object sender, EventArgs e)
    {
        Shop myShop = (Shop)Session["myShop"];
        productId = Convert.ToString(Request.QueryString["ProductId"]);//Gets the id from the address bar
        Product viewedProduct;  

        if (productId != null) //If there is an id being passed through
        {
            viewedProduct = (Product)myShop.GetProduct(productId); //Gets the product object linked to the id

            if (viewedProduct != null) //if the product exists
            {
                if (viewedProduct.QuantityHeld > 0) //if the product is in stock
                {
                    if (!Page.IsPostBack)
                    {
                        //Sets the max value of the dropdown to the max quantity of the product
                        ddlQuantity.DataSource = Enumerable.Range(1, viewedProduct.QuantityHeld); 
                        ddlQuantity.DataBind();
                    }  
                }
                else 
                {
                    //If there product is out stock, remove adding options and give an error message
                    ddlQuantity.Visible = false;
                    lbAddToCart.Visible = false;
                    lblOutOfStock.Text = "This item is out of stock!";
                }
            }
            else
            {
                //If the product does not exist, show an error message and hide all form information
                ddlQuantity.Visible = false;
                lbAddToCart.Visible = false;
                fvProductDetail.Visible = false;
                ddlQuantity.Visible = false;
                lblOutOfStock.Text = "No Product Found!";
            }
            fvProductDetail.DataSource = myShop.getProductDetails(productId); //Shows product info
            fvProductDetail.DataBind();
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Products.aspx");
    }

    protected void lbAddToCart_Click(object sender, EventArgs e)
    {
        //Redirects to the AddToCart page and passes through the product id and quantity
        int quantity = Convert.ToInt32(ddlQuantity.SelectedValue);
        Response.Redirect("AddToCart.aspx?ProductId=" + productId + "&Quantity=" + quantity);
    }

}