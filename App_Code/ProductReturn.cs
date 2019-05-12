using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class ProductReturn
{
    private string returnId;
    private string productId;
    private string orderId;
    private string orderLineId;
    private string returnDate; 
    private string reason;
    private string condition;
    private string username;
    private bool approved;

    public string ReturnId
    {
        get { return returnId; }
        set { returnId = value; }
    }
    public string ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public string OrderId
    {
        get { return orderId; }
        set { orderId = value; }
    }

    public string OrderLineId
    {
        get { return orderLineId; }
        set { orderLineId = value; }
    }

    public string ReturnDate
    {
        get { return returnDate; }
        set { returnDate = value; }
    }

    public string Reason
    {
        get { return reason; }
        set { reason = value; }
    }

    public string Condition
    {
        get { return condition; }
        set { condition = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public bool Approved
    {
        get { return approved; }
        set { approved = value; }
    }

	public ProductReturn()
	{
        returnId = "";
        productId = "";
        orderId = "";
        orderLineId = "";
        returnDate = "";
        reason = "";
        condition = "";
        username = "";
        approved = false;
	}

    public ProductReturn(string ReturnId, string ProductId, string OrderId, string OrderLineId, string Reason, string Condition, string Username)
    {
        returnId = ReturnId;
        productId = ProductId;
        orderId = OrderId;
        orderLineId = OrderLineId;
        returnDate = Convert.ToString(DateTime.Now).Substring(0,10);
        reason = Reason;
        condition = Condition;
        username = Username;
        approved = false;
    }

    public ProductReturn(string ReturnId, string ProductId, string OrderId, string OrderLineId, string ReturnDate, string Reason, string Condition, string Username, bool Approved)
    {
        returnId = ReturnId;
        productId = ProductId;
        orderId = OrderId;
        orderLineId = OrderLineId;
        returnDate = ReturnDate;
        reason = Reason;
        condition = Condition;
        username = Username;
        approved = Approved;
    }
}