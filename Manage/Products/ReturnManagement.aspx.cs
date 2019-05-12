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

public partial class Manage_Products_ReturnManagement : System.Web.UI.Page
{
    Shop myShop;
    Staff staffMember;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if an admin/stock manager is logged in
        if ((string)Session["UserType"] == "Administrator" || (string)Session["UserType"] == "Stock Manager")
        { 
            myShop = (Shop)Session["myShop"];
            staffMember = (Staff)Session["staffMember"];

            //Gets the returnId and action (Approve or Remove) from the address bar
            string returnId = Convert.ToString(Request.QueryString["ReturnId"]); 
            string action = Convert.ToString(Request.QueryString["Action"]); 

            if (returnId != null)
            {
                if (action == "Approve")
                {
                    DataAccess dbAccess = new DataAccess();
                    ProductReturn ProductReturned = (ProductReturn)myShop.GetProductReturn(returnId); 
                    Order aOrder = (Order)staffMember.GetOrder(ProductReturned.OrderId); 
                    aOrder.OrderLines = dbAccess.loadUserOrderLines(aOrder);
                    OrderLine aOrderLine = aOrder.GetOrderLine(ProductReturned.OrderLineId); 
                    Product aProduct = myShop.GetProduct(aOrderLine.ProductId); 

                    //Updates stock when product has been returned
                    int quantity = aOrderLine.Quantity; 
                    aProduct.QuantityHeld = (aProduct.QuantityHeld + quantity); 
                    myShop.updateProduct(aProduct);

                    ProductReturned.Approved = true;
                    myShop.updateProductReturn(ProductReturned);
                }
                else
                {
                    myShop.removeProductReturn(returnId); //Removes the productreturn from the shop
                }
                Response.Redirect("ReturnManagement.aspx");
            }

            if (myShop.ShopProductReturns.Count < 1)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No products currently being requested to be returned";
            }
            else
            {
                gvReturnList.DataSource = myShop.ShopProductReturns; 
                gvReturnList.DataBind();
            }
        }      
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}