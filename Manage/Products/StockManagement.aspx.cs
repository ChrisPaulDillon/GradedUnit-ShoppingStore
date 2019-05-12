using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Manage_Products_StockManagement : System.Web.UI.Page
{
    Shop myShop;
    Staff staffMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if an admin/stock manager is logged in
        if ((String)Session["UserType"] == "Administrator" || (String)Session["UserType"] == "Stock Manager")
        {
            myShop = (Shop)Session["myShop"];
            staffMember = (Staff)Session["staffMember"];

            //Gets the productId and action (Reorder or Remove) from the address bar
            string productId = Convert.ToString(Request.QueryString["ProductId"]);
            string action = Convert.ToString(Request.QueryString["Action"]);

            if (productId != null && action != null) //If there is a productId and action being passed through the address bar
            {
                if (myShop.GetProduct(productId) != null) //If the product is found and is low stock
                {
                    if (action == "Reorder")
                    {
                        Product reorderedProduct = (Product)myShop.GetProduct(productId); //Gets product from shop
                        reorderedProduct.QuantityHeld = (reorderedProduct.QuantityHeld + reorderedProduct.ReorderQuantity); //Updates the quantity held
                        myShop.updateProduct(reorderedProduct);

                        if (reorderedProduct.QuantityHeld > reorderedProduct.ReorderLevel)
                        {
                            myShop.getLowStockProducts().Remove(productId); //Removes the product from low stock if no longer low in stock
                        }
                    }
                    else
                    {
                        myShop.removeProduct(productId); //Removes the product completely
                    }
                    Response.Redirect("StockManagement.aspx");
                }
            }

            string input = txtSearch.Text; //Gets user search input

            if (input != "")
            {
                gvStockList.Columns[6].Visible = false;
                gvStockList.DataSource = myShop.searchProducts(input); //Displays all products from the search result in the gridview
                gvStockList.DataBind();
            }
            else
            {
                gvStockList.Columns[6].Visible = false;
                gvStockList.DataSource = myShop.ShopProducts; //Dispalys all products in the gridview
                gvStockList.DataBind();
            }
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProducts.SelectedValue == "All")
        {
            gvStockList.Columns[6].Visible = false;
            gvStockList.DataSource = myShop.ShopProducts; //Displays all shop products in the gridview
            gvStockList.DataBind();
            lblMessage.Visible = false;
        }

        if (ddlProducts.SelectedValue == "Low Stock")
        {
            gvStockList.Columns[6].Visible = true;
            gvStockList.DataSource = myShop.getLowStockProducts(); //Displays all products low in stock
            gvStockList.DataBind();

            if (myShop.getLowStockProducts().Count < 1) //Displays a message if there no products low in stock
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No products currently low on stock!";
            }
        }
    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/Products/AddProduct.aspx");
    }
}