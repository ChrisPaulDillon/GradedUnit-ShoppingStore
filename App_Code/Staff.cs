using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class Staff : User
{
    private string jobTitle;
    private Dictionary<string, Order> staffOrders;

    public string JobTitle
    {
        get { return jobTitle; }
        set { jobTitle = value; }
    }

    public Dictionary<string, Order> StaffOrders
    {
        get { return staffOrders; }
        set { staffOrders = value; }
    }

    //Used for adding staff members through the administrator

    public Staff(string aUser, string aPass, string aJobTitle, string aFirstName, string aLastName, string aStreet, string aTown, string aPostcode, string aPhoneNo, string aEmail) :
        base(aUser, aPass, aFirstName, aLastName, aStreet, aTown, aPostcode, aPhoneNo, aEmail)
    {
        jobTitle = aJobTitle;
        staffOrders = new Dictionary<string, Order>();
    }

    public Staff()
    {
        jobTitle = "";
        staffOrders = new Dictionary<string, Order>();
    }

    /*
     * Used to update the shipping status and staff username in the Order.
     * Checks if the order is found and then replaces the previous Order object
     * with the updated version
     * 
     * @param aOrder - The Order object with the updated values
     * */

    public void updateOrder(Order aOrder)
    {
        foreach (KeyValuePair<string, Order> curOrder in staffOrders.ToList())
        {
            if (curOrder.Value.OrderId == aOrder.OrderId)  //if the order is found
            {
                DataAccess dbAccess = new DataAccess();
                staffOrders[curOrder.Key] = aOrder;
                dbAccess.updateOrder(aOrder);
            }
        }
    }

    /*
     * Used to get all orders currently unshipped. Checks each individual order for
     * not yet dispatched and if true it will add it to the dictionary.
     * 
     * @param input - The string used for the search result
     * @return productDetail - A Dictionary used to hold all orders from the search result
     * */

    public Dictionary<string, Order> getUnshippedOrders()
    {
        Dictionary<string, Order> unshippedOrders;
        unshippedOrders = new Dictionary<string, Order>();

        foreach (KeyValuePair<string, Order> curOrder in staffOrders)
        {
            if (curOrder.Value.ShippingStatus == "Not Yet Dispatched")
            {
                unshippedOrders.Add(curOrder.Value.OrderId, curOrder.Value);
            }
        }
        return unshippedOrders;
    }

    /*
     * Used to get the Order object based on the Id
     * and will return that object if it exists within the dictionary
     * 
     * @param orderId - The Id being input from the user
     * @return - The object found with the corresponding id
     * 
     * */

    public Order GetOrder(string orderId)
    {
        foreach (KeyValuePair<string, Order> curOrder in staffOrders)
        {
            if (curOrder.Value.OrderId == orderId)
            {
                return curOrder.Value;
            }
        }
        return null;
    }
}