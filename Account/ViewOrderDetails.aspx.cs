using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class Account_ViewOrderDetails : System.Web.UI.Page
{
    Customer customerMember;
    Order viewedOrder;

    protected void Page_Load(object sender, EventArgs e)
    {
        string orderId = Convert.ToString(Request.QueryString["OrderId"]);

        //If the user logged in is a customer and there is a valid orderId
        if ((string)Session["UserType"] == "Customer" && orderId != null)
        {
            customerMember = (Customer)Session["customerMember"];
            Shop myShop = (Shop)Session["myShop"];
            viewedOrder = customerMember.GetOrder(orderId);

            DataAccess dbAccess = new DataAccess();
            //Loads the orderLine from the database
            viewedOrder.OrderLines = dbAccess.loadUserOrderLines(viewedOrder);

            //Populates the Product object for each orderline
            foreach (KeyValuePair<string, OrderLine> curOrderLine in viewedOrder.OrderLines)
            {
                curOrderLine.Value.Product = myShop.GetProduct(curOrderLine.Value.ProductId);
            }

            Session.Add("ViewedOrder", viewedOrder); //Order to be passed to the ReturnItem page

            gvOrderLines.DataSource = viewedOrder.OrderLines; 
            gvOrderLines.DataBind();

            lblShippingMethod.Text = viewedOrder.getShippingMethod(); //Gets the shipping method based on the price
            lblTotal.Text = String.Format("{0:c}", viewedOrder.Total); //Formats the order total
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/MyOrders.aspx");
    }
    
    //Used to export to xml
    protected void btnExport_Click(object sender, EventArgs e)
    {
            var xEle = new XElement("Order",
                new XElement("FirstName", customerMember.FirstName),
                new XElement("LastName", customerMember.LastName),
                from orderLine in viewedOrder.OrderLines
                select new XElement("OrderLine",
                    new XElement("ProductName", orderLine.Value.Product.ProductName),
                    new XElement("Price", orderLine.Value.Product.UnitPrice),
                    new XElement("Quantity", orderLine.Value.Quantity)
                    ),
                    new XElement("ShippingMethod", viewedOrder.getShippingMethod()),
                    new XElement("OrderTotal", viewedOrder.Total)
                    );

            HttpContext context = HttpContext.Current;
            context.Response.Write(xEle);
            context.Response.ContentType = "application/xml";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=ProductData.xml");
            context.Response.End();
        }
}