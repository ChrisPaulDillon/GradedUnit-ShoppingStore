using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class Order
{
    private string orderId;
    private string staffUser;
    private string username;
    private string orderDate;
    private decimal? shippingPrice;
    private decimal? total;
    private string shippingStatus;
    private Dictionary<string, OrderLine> orderLines;

    public string OrderId
    {
        get { return orderId; }
        set { orderId = value; }
    }

    public string StaffUser
    {
        get { return staffUser; }
        set { staffUser = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public string OrderDate
    {
        get { return orderDate; }
        set { orderDate = value; }
    }

    public decimal? ShippingPrice
    {
        get { return shippingPrice; }
        set { shippingPrice = value; }
    }

    public decimal? Total
    {
        get { return total; }
        set { total = value; }
    }

    public string ShippingStatus
    {
        get { return shippingStatus; }
        set { shippingStatus = value; }
    }

    public Dictionary<string, OrderLine> OrderLines
    {
        get { return orderLines; }
        set { orderLines = value; }
    }

    public Order()
    {
        orderId = "";
        staffUser = "";
        username = "";
        orderDate = "";
        shippingPrice = 0;
        total = 0.00M;
        shippingStatus = "";
        orderLines = new Dictionary<string, OrderLine>();
    }

    //Constructor used for loading orders
    public Order(string OrderId, string StaffUser, string Username, string OrderDate, decimal ShippingPrice, decimal Total, string ShippingStatus)
    {
        orderId = OrderId;
        staffUser = StaffUser;
        username = Username;
        orderDate = OrderDate;
        shippingPrice = ShippingPrice;
        total = Total;
        shippingStatus = ShippingStatus;
        orderLines = new Dictionary<string, OrderLine>();
    }

    public Order(string OrderId, string Username)
    {
        orderId = OrderId;
        staffUser = "Not Assigned";
        username = Username;
        orderDate = null;
        shippingPrice = null;
        total = null;
        shippingStatus = "Not Yet Dispatched";
        orderLines = new Dictionary<string, OrderLine>();
    }

    /*
     * Adds the orderline if the dictionary does not contain the key
     * 
     * @param newOrderLine - The orderline being added to the dictionary
     * */

    public void addOrderLine(OrderLine newOrderline)
    {
        if (!orderLines.ContainsKey(newOrderline.OrderLineId))
        {
            orderLines.Add(newOrderline.OrderLineId, newOrderline);
        }
    }

    /*
     * Gets the orderline object using the orderlineid from the dictionary
     * 
     * @return curOrderLine - The orderline object linked to the orderlineid
     * */

    public OrderLine GetOrderLine(string orderLineId)
    {
        foreach (KeyValuePair<string, OrderLine> curOrderLine in orderLines)
        {
            if (curOrderLine.Value.OrderLineId == orderLineId)
            {
                return curOrderLine.Value;
            }
        }
        return null;
    }

    /*
     * Gets the shipping method based on the price
     * 
     * @return method - The method of shipping used
     * */

    public string getShippingMethod()
    {
        string method;

        if (shippingPrice == 0.00M)
        {
            method = "Standard";
            return method;
        }
        else
        {
            method = "NextDay";
            return method;
        }
    }

    /*
     * Compares the current date to the order date and returns a bool
     * based on the result
     * 
     * @param isCancelable - The bool used to determine if the order is cancellable
     * */

    public bool isOrderCancelable()
    {
        DateTime orderDate = DateTime.Now;
        DateTime orderReturnDate = Convert.ToDateTime(OrderDate).AddDays(2.0);

        int result = DateTime.Compare(orderDate, orderReturnDate);
        bool isCancelable = false;

        //A result of 0 or less than 0 means the order return date is older than the current date
        if (result < 0 || result == 0)
        {
            isCancelable = true;
            return isCancelable;
        }
        return isCancelable;
    }
}