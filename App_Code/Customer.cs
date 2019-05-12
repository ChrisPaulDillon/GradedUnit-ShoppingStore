using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Twilio;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class Customer : User
{
    private Order cartOrder;
    private Dictionary<string, Order> customerOrders;

    public Order CartOrder
    {
        get { return cartOrder; }
        set { cartOrder = value; }
    }

    public Dictionary<string, Order> CustomerOrders
    {
        get { return customerOrders; }
        set { customerOrders = value; }
    }

    public Customer(string User, string Pass, string FName, string LName, string Street, string Town, string Postcode, string PhoneNo, string Email) :
        base(User, Pass, FName, LName, Street, Town, Postcode, PhoneNo, Email)
    {
        customerOrders = new Dictionary<string, Order>();
    }

    public Customer()
        : base()
    {
        customerOrders = new Dictionary<string, Order>();
    }

    public Customer(string aUsername, string aPassword, string aEmail) //Used for logging in
        : base()
    {
        Username = aUsername;
        Password = aPassword;
        Email = aEmail;
        customerOrders = new Dictionary<string, Order>();
    }

    public Customer(string aUsername)
        : base()
    {
        Username = aUsername;
        customerOrders = new Dictionary<string, Order>();
    }

    /**
     * Checks to see if the user has missing details in any of the customer information.
     * If any detail returns empty then the method will return true
     * 
     * @Return missingDetails - The bool which returns whether the user has info missing or not
     * 
     * */

    public bool checkMissingDetails()
    {
        bool missingDetails = false;
        if (FirstName == "" || LastName == "" || Street == "" || Town == "" || Postcode == "" || PhoneNo == "")
        {
            return missingDetails = true;
        }
        return missingDetails;
    }

    /*
     * Adds a new Order object to the shopOrders dictionary
     * if the orderId does not exist
     * 
     * @param aOrder - The Order object being added to the dictionary      
     * */

    public void addOrder()
    {
        if (!customerOrders.ContainsKey(cartOrder.OrderId))
        {
            DataAccess dbAccess = new DataAccess();
            customerOrders.Add(cartOrder.OrderId, cartOrder);
            dbAccess.addOrder(cartOrder);
        }
    }

    /*
     * Gets the Order object with the corresponding orderId from the input
     * 
     * @param curOrder - The Order object with the orderId from the input 
     * */

    public Order GetOrder(string orderId)
    {
        foreach (KeyValuePair<string, Order> curOrder in customerOrders)
        {
            if (curOrder.Value.OrderId == orderId)
            {
                return curOrder.Value;
            }
        }
        return null;
    }

    /*
     * Adds a new orderline if the product is not already in basket
     * else updates the existing orderline with the quantity
     * 
     * @param productId - Used to get the product linked to the id
     * @param quantityAddded - Used to update the quantity of the product
     * 
     * */
    public void addToCart(string productId, int quantityAdded)
    {
        Shop myShop = new Shop();
        Product aProduct = (Product)myShop.GetProduct(productId);
        if (cartItemExists(productId) != null)
        {
            OrderLine aOrderLine = (OrderLine)cartItemExists(productId);
            aOrderLine.Quantity = (aOrderLine.Quantity + quantityAdded);
            updateCartItem(aOrderLine);
        }
        else
        {
            OrderLine aOrderLine = new OrderLine(Guid.NewGuid().ToString(), CartOrder.OrderId, productId, quantityAdded);
            aOrderLine.addProduct(aProduct);
            cartOrder.addOrderLine(aOrderLine);
        }
    }

    /**
     * Checks if an orderLine already exists in the users cart
     * 
     * @param productId - Gets the orderline linked to the productId
     * @return curCartItem - The orderline linked to the productId
     * */

    public OrderLine cartItemExists(string productId)
    {
        foreach (KeyValuePair<string, OrderLine> curCartItem in CartOrder.OrderLines)
        {
            if (curCartItem.Value.ProductId == productId)
            {
                return curCartItem.Value;
            }
        }
        return null;
    }

    /*
     * Removes the orderline linked to the id if found
     * 
     * @param id - The id of the orderline being requested to be removed
     * */

    public void removeCartItem(string id)
    {
        if (cartOrder.OrderLines.ContainsKey(id))
        {
            cartOrder.OrderLines.Remove(id);
        }
    }

    /*
     * Finds and updates the orderline linked to the orderlineId from the input
     * 
     * @param aOrderLine - The orderLine being requested to be updated
     * */

    public void updateCartItem(OrderLine aOrderLine)
    {
        foreach (KeyValuePair<string, OrderLine> curCartItem in cartOrder.OrderLines.ToList())
        {
            if (aOrderLine.OrderLineId == curCartItem.Value.OrderLineId)
            {
                CartOrder.OrderLines[curCartItem.Key] = aOrderLine;
            }
        }
    }

    /*
     * Removes the order linked to the orderId if found
     * 
     * @param aOrder - The Order object being requested to be removed
     * */

    public void removeOrder(Order aOrder)
    {
        if (customerOrders.ContainsKey(aOrder.OrderId))
        {
            DataAccess dbAccess = new DataAccess();
            customerOrders.Remove(aOrder.OrderId);
            dbAccess.removeUserOrder(aOrder);
        }
    }


    /*
     * Finds and updates the order linked to the orderId from the input
     * 
     * @param aOrder - The order being requested to be updated
     * */

    public void updateOrder(Order aOrder)
    {
        foreach (KeyValuePair<string, Order> curOrder in customerOrders)
        {
            if (curOrder.Value.OrderId == aOrder.OrderId)
            {
                customerOrders[curOrder.Key] = aOrder;
            }
        }
    }

    /*
     * Calculates the total of the current amount of items in the cart
     * 
     * @return total - The order total without shipping expenses
     * */

    public decimal calcCartTotal()
    {
        decimal total = 0.00M;

        foreach (KeyValuePair<string, OrderLine> curCartItem in cartOrder.OrderLines)
        {
            total += curCartItem.Value.Product.UnitPrice * curCartItem.Value.Quantity;
        }
        return total;
    }

    /*
     * Calculates the total of the current amount of items in the cart.
     * Finally adds the shippingCost on top of it.
     * 
     * @param shippingCost - The cost of the shipping for the order
     * @return total - The order total with shipping expenses
     * */

    public decimal calcCartTotal(decimal shippingCost)
    {
        decimal total = 0.00M;

        foreach (KeyValuePair<string, OrderLine> curCartItem in cartOrder.OrderLines)
        {
            total += curCartItem.Value.Product.UnitPrice * curCartItem.Value.Quantity;
        }

        total = total + shippingCost;
        return total;
    }

    //Empties the dictionary of orderlines when called

    public void emptyUserCart()
    {
        cartOrder.OrderLines.Clear();
    }

    /*
     * Takes in the total and sends the user a text confirming their order
     * and stating their order total
     * 
     * @param total - The order total being checked out
     * */

    public void sendSmsOrderConfirmation(decimal? total)
    {
        string smsMessage = "Thank you for your purchase " + Username + ", your total order came to £" + total;
        string ACCOUNT_SID = "ACc70c9deda9b88625b922183301e58764";
        string AUTH_TOKEN = "e3a201b3c626779c4d8b0c546d472212";
        TwilioRestClient client = new TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN);
        try
        {
            client.SendSmsMessage("441158241640", PhoneNo, smsMessage);
        }

        catch (Exception ex)
        {
            Exception e = ex;
        }
    }

    //Sends a basic confirmation message through email to the user signing up

    public void sendSignUpMail()
    {
        var fromAddress = "opencomputingsupplies@gmail.com";// Email Address
        var toAddress = Email;
        const string fromPassword = "ocspass1";//Password
        string subject = "Successfully signed up at Open Computing Supplies";
        string body = "Thank you for signing up to Open Computing Supplies!";

        try
        {
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            smtp.Send(fromAddress, toAddress, subject, body);
        }
        catch (SmtpException ex)
        {
            Exception e = ex;
        }
    }

    //Sends the user their total and a success message through email

    public void sendOrderConfirmationEmail(decimal? total)
    {
        var fromAddress = "opencomputingsupplies@gmail.com";// Email Address
        var toAddress = Email;
        const string fromPassword = "ocspass1";//Password
        string subject = "Thank you for placing an order at Open Computing Supplies";
        string body = "Thank you for your purchase " + Username + ", your total order came to £" + total;

        try
        {
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        catch (SmtpException ex)
        {
            Exception e = ex;
        }
    }

    /*
     * Creates a form using StringBuilder which is passed through 
     * when the user checks out with paypal
     * 
     * @return ppForm - The form used to check out with paypal
     * */

    public string paypalCheckout()
    {
        //PayPal cart version
        string PostUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        string Cmd = "_cart";
        string Upload = "1";
        string BusinessEmail = "seller@opencomputingsupplies.com";
        string Currency = "GBP";
        string Method = "post";

        //Create the Form to write to the page with PayPal parameters
        StringBuilder ppForm = new StringBuilder();
        ppForm.AppendFormat("<Form name='frmPP' id='frmPP' action='{0}' method='{1}'>", PostUrl, Method);
        ppForm.AppendFormat("<input type='hidden' name='cmd' value='{0}'>", Cmd);
        ppForm.AppendFormat("<input type='hidden' name='upload' value='{0}'>", Upload);
        ppForm.AppendFormat("<input type='hidden' name='business' value='{0}'>", BusinessEmail);
        ppForm.AppendFormat("<input type='hidden' name='currency_code' value='{0}'>", Currency);
        int counter = 1;
        foreach (KeyValuePair<string, OrderLine> curCartItem in cartOrder.OrderLines)
        {
            ppForm.AppendFormat("<input type='hidden' name='item_name_" + counter + "' value='{0}'>", curCartItem.Value.Product.ProductName);
            ppForm.AppendFormat("<input type='hidden' name='amount_" + counter + "' value='{0}'>", curCartItem.Value.Product.UnitPrice);
            ppForm.AppendFormat("<input type='hidden' name='quantity_" + counter + "' value='{0}'>", curCartItem.Value.Quantity);
            counter++;
        }
        ppForm.Append("</form>");
        return ppForm.ToString();
    }
}