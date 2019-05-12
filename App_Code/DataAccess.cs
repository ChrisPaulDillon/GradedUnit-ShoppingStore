using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class DataAccess
{
    private Dictionary<string, Product> shopProducts;
    private Dictionary<string, Customer> shopCustomers;
    private Dictionary<string, Staff> shopStaff;
    private Dictionary<string, Order> shopOrders;
    private Dictionary<string, OrderLine> shopOrderLines;
    private Dictionary<string, ProductReturn> shopProductReturns;
    private Dictionary<string, Location> shopLocations;
    private string connStr = ConfigurationManager.ConnectionStrings["OCS1"].ConnectionString;

    /*
     * Makes a call to the database getting all products
     * and loading them into a dictionary
     * 
     * @reutrn shopProducts - A dictionary of product objects
     * */

    public Dictionary<string, Product> loadProducts()
    {
        shopProducts = new Dictionary<string, Product>();

        string sqlQuery = "SELECT * FROM Products";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string productId = Convert.ToString(myDataTable.Rows[i][0]);
            string productName = Convert.ToString(myDataTable.Rows[i][1]);
            string description = Convert.ToString(myDataTable.Rows[i][2]);
            int unitPrice = Convert.ToInt32(myDataTable.Rows[i][3]);
            int quantityHeld = Convert.ToInt32(myDataTable.Rows[i][4]);
            int reorderLevel = Convert.ToInt32(myDataTable.Rows[i][5]);
            int reorderQuantity = Convert.ToInt32(myDataTable.Rows[i][6]);
            string imgPath = Convert.ToString(myDataTable.Rows[i][7]);
            
            Product aProduct = new Product(productId, productName, description, unitPrice, quantityHeld, reorderLevel, reorderQuantity, imgPath);

            if (!shopProducts.ContainsKey(productId))
            {
                shopProducts.Add(productId, aProduct);
            }

        }
        return shopProducts;
    }

    /*
     * Makes a call to the database getting all customers
     * and loading them into a dictionary
     * 
     * @reutrn shopCustomers - A dictionary of customer objects
     * */

    public Dictionary<string, Customer> loadCustomers()
    {
        shopCustomers = new Dictionary<string, Customer>();

        string sqlQuery = "SELECT * FROM Customers";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string user = Convert.ToString(myDataTable.Rows[i][0]);
            string pass = Convert.ToString(myDataTable.Rows[i][1]);
            string fName = Convert.ToString(myDataTable.Rows[i][2]);
            string lName = Convert.ToString(myDataTable.Rows[i][3]);
            string street = Convert.ToString(myDataTable.Rows[i][4]);
            string town = Convert.ToString(myDataTable.Rows[i][5]);
            string postcode= Convert.ToString(myDataTable.Rows[i][6]);
            string phoneNo = Convert.ToString(myDataTable.Rows[i][7]);
            string email = Convert.ToString(myDataTable.Rows[i][8]);

            Customer aCustomer = new Customer(user, pass, fName, lName, street, town, postcode, phoneNo, email);

            if (!shopCustomers.ContainsKey(user))
            {
                shopCustomers.Add(user, aCustomer);
            }

        }
        return shopCustomers;
    }

    /*
     * Makes a call to the database getting all staff
     * and loading them into a dictionary
     * 
     * @reutrn shopStaff - A dictionary of staff objects
     * */

    public Dictionary<string, Staff> loadStaff()
    {
        shopStaff = new Dictionary<string, Staff>();

        string sqlQuery = "SELECT * FROM Staff";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string user = Convert.ToString(myDataTable.Rows[i][0]);
            string pass = Convert.ToString(myDataTable.Rows[i][1]);
            string job = Convert.ToString(myDataTable.Rows[i][2]);
            string fName = Convert.ToString(myDataTable.Rows[i][3]);
            string lName = Convert.ToString(myDataTable.Rows[i][4]);
            string street = Convert.ToString(myDataTable.Rows[i][5]);
            string town = Convert.ToString(myDataTable.Rows[i][6]);
            string postcode = Convert.ToString(myDataTable.Rows[i][7]);
            string phoneNo = Convert.ToString(myDataTable.Rows[i][8]);
            string email = Convert.ToString(myDataTable.Rows[i][9]);

            Staff aStaff = new Staff(user, pass, job, fName, lName, street, town, postcode, phoneNo, email);

            if (!shopStaff.ContainsKey(user))
            {
                shopStaff.Add(user, aStaff);
            }

        }
        return shopStaff;

    }

    /*
     * Makes a call to the database getting all orders
     * and loading them into a dictionary
     * 
     * @reutrn shopOrders - A dictionary of order objects
     * */

    public Dictionary<string, Order> loadOrders()
    {
        shopOrders = new Dictionary<string, Order>();

        string sqlQuery = "SELECT * FROM Orders";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string orderId = Convert.ToString(myDataTable.Rows[i][0]);
            string staffUser = Convert.ToString(myDataTable.Rows[i][1]);
            string user = Convert.ToString(myDataTable.Rows[i][2]);
            string orderDate = Convert.ToString(myDataTable.Rows[i][3]);
            decimal shippingMethod = Convert.ToDecimal(myDataTable.Rows[i][4]);
            decimal total = Convert.ToDecimal(myDataTable.Rows[i][5]);
            string hasBeenShipped = Convert.ToString(myDataTable.Rows[i][6]);

            Order aOrder = new Order(orderId, staffUser, user, orderDate, shippingMethod, total, hasBeenShipped);

            if (!shopOrders.ContainsKey(orderId))
            {
                shopOrders.Add(orderId, aOrder);
            }

        }
        return shopOrders;
    }

    /*
     * Makes a call to the database getting all orders linked to the username
     * from input and adds them to the dictionary
     * 
     * @reutrn shopOrders - A dictionary of order objects
     * */

    public Dictionary<string, Order> loadUserOrders(string username)
    {
        shopOrders = new Dictionary<string, Order>();

        string sqlQuery = "SELECT * FROM Orders WHERE Username = '" + username + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string orderId = Convert.ToString(myDataTable.Rows[i][0]);
            string staffUser = Convert.ToString(myDataTable.Rows[i][1]);
            string user = Convert.ToString(myDataTable.Rows[i][2]);
            string orderDate = Convert.ToString(myDataTable.Rows[i][3]);
            decimal shippingMethod = Convert.ToDecimal(myDataTable.Rows[i][4]);
            decimal total = Convert.ToDecimal(myDataTable.Rows[i][5]);
            string hasBeenShipped = Convert.ToString(myDataTable.Rows[i][6]);

            Order aOrder = new Order(orderId, staffUser, user, orderDate, shippingMethod, total, hasBeenShipped);

            if (!shopOrders.ContainsKey(orderId))
            {
                shopOrders.Add(orderId, aOrder);
            }

        }
        return shopOrders;
    }

    /*
     * Makes a call to the database getting all productreturns
     * and loading them into a dictionary
     * 
     * @reutrn shopStaff - A dictionary of productreturn objects
     * */

    public Dictionary<string, ProductReturn> loadProductReturns()
    {
        shopProductReturns = new Dictionary<string, ProductReturn>();

        string sqlQuery = "SELECT * FROM ProductReturns WHERE Approved = '" + false + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string returnId = Convert.ToString(myDataTable.Rows[i][0]);
            string productId = Convert.ToString(myDataTable.Rows[i][1]);
            string orderId = Convert.ToString(myDataTable.Rows[i][2]);
            string orderLineId = Convert.ToString(myDataTable.Rows[i][3]);
            string returnDate = Convert.ToString(myDataTable.Rows[i][4]);
            string reason = Convert.ToString(myDataTable.Rows[i][5]);
            string condition = Convert.ToString(myDataTable.Rows[i][6]);
            string username = Convert.ToString(myDataTable.Rows[i][7]);
            bool approved = Convert.ToBoolean(myDataTable.Rows[i][8]);

            ProductReturn aProduct = new ProductReturn(returnId, productId, orderId, orderLineId, returnDate, reason, condition, username, approved);

            if (!shopProductReturns.ContainsKey(returnId))
            {
                shopProductReturns.Add(returnId, aProduct);
            }

        }
        return shopProductReturns;
    }

    /*
     * Makes a call to the database getting all orderlines linked to
     * the Order being passed through and adding them to a dictionary
     * 
     * @reutrn shopOrderLines - A dictionary of orderline objects
     * */

    public Dictionary<string, OrderLine> loadUserOrderLines(Order aOrder)
    {
        shopOrderLines = new Dictionary<string, OrderLine>();

        string sqlQuery = "SELECT * FROM OrderLines WHERE OrderId = '" + aOrder.OrderId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string orderLineId= Convert.ToString(myDataTable.Rows[i][0]);
            string orderId = Convert.ToString(myDataTable.Rows[i][1]);
            string productId = Convert.ToString(myDataTable.Rows[i][2]);
            int quantity = Convert.ToInt32(myDataTable.Rows[i][3]);


            OrderLine aOrderLine = new OrderLine(orderLineId, orderId, productId, quantity);

            if (!shopOrderLines.ContainsKey(orderLineId))
            {
                shopOrderLines.Add(orderLineId, aOrderLine);
            }

        }
        return shopOrderLines;

    }

    /*
     * Makes a call to the database getting all locations
     * and loading them into a dictionary
     * 
     * @reutrn shopLocations - A dictionary of location objects
     * */

    public Dictionary<string, Location> loadLocations()
    {
        shopLocations = new Dictionary<string, Location>();

        string sqlQuery = "SELECT * FROM Locations";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
        DataTable myDataTable = new DataTable();

        myConnection.Open();
        dataAdapter.Fill(myDataTable);
        myConnection.Close();
        dataAdapter.Dispose();

        for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
        {
            string locationId = Convert.ToString(myDataTable.Rows[i][0]);
            string locLat = Convert.ToString(myDataTable.Rows[i][1]);
            string locLong = Convert.ToString(myDataTable.Rows[i][2]);

            Location aLocation = new Location(locationId, locLat, locLong);

            if (!shopLocations.ContainsKey(locationId))
            {
                shopLocations.Add(locationId, aLocation);
            }

        }
        return shopLocations;

    }

    /*
     * Adds an order to the database taken from the input.
     * Adds each orderline linked to the order from the input.
     * 
     * @param aOrder - The order being added to the database
     * */
    public void addOrder(Order aOrder)
    {
        string sqlQuery = "INSERT INTO Orders VALUES ('" + aOrder.OrderId + "','" + aOrder.StaffUser + "','" + aOrder.Username + "','" + aOrder.OrderDate + "','" + aOrder.ShippingPrice + "','" + aOrder.Total + "','" + aOrder.ShippingStatus + "')";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }

        foreach (KeyValuePair<string, OrderLine> curOrderLine in aOrder.OrderLines)
        {
            string sqlQuery2 = "INSERT INTO OrderLines VALUES('" + curOrderLine.Value.OrderLineId + "','" + curOrderLine.Value.OrderId + "','" +
                                                            curOrderLine.Value.ProductId + "','" + curOrderLine.Value.Quantity + "')";
            
            SqlConnection myConnection2 = new SqlConnection(connStr);
            SqlCommand myCommand2 = new SqlCommand(sqlQuery2, myConnection2);

            try
            {
                myConnection2.Open();
                myCommand2.ExecuteNonQuery();
                myConnection2.Close();
            }
            catch (Exception ex)
            {
                Exception e = ex;
                myConnection.Close();
            }
        }
    }

    /*
     * Adds a productreturn to the database taken from the input.
     * 
     * @param aProductReturn - The productreturn being added to the database
     * */

    public void addProductReturn(ProductReturn aProductReturn)
    {
        string sqlQuery = "INSERT INTO ProductReturns VALUES ('" + aProductReturn.ReturnId + "','" + aProductReturn.ProductId + "','" + aProductReturn.OrderId + "','" + aProductReturn.OrderLineId + "','" + aProductReturn.ReturnDate + "','" + aProductReturn.Reason + "','" + aProductReturn.Condition + "','" + aProductReturn.Username + "','" + aProductReturn.Approved + "')";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Adds a product to the database taken from the input.
     * 
     * @param aProduct - The product being added to the database
     * */

    public void addProduct(Product newProduct)
    {
        string sqlQuery = "INSERT INTO Products VALUES ('" + newProduct.ProductId + "','" + newProduct.ProductName + "','" + newProduct.Description + "','" + newProduct.UnitPrice + "','" + newProduct.QuantityHeld + "','" + newProduct.ReorderLevel + "','" + newProduct.ReorderQuantity + "','" + newProduct.ImgPath + "')";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Adds a customer to the database taken from the input.
     * 
     * @param aCustomer - The customer being added to the database
     * */

    public void addCustomer(Customer aCustomer)
    {
        string sqlQuery = "INSERT INTO Customers VALUES ('" + aCustomer.Username + "','" + aCustomer.Password + "','" + aCustomer.FirstName + "','" + aCustomer.LastName + "','" + aCustomer.Street + "','" + aCustomer.Town + "','" + aCustomer.Postcode + "','" + aCustomer.PhoneNo + "','" + aCustomer.Email + "')";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Adds a staff to the database taken from the input.
     * 
     * @param aStaff - The staff member being added to the database
     * */

    public void addStaff(Staff aStaff)
    {
        string sqlQuery = "INSERT INTO Staff VALUES ('" + aStaff.Username + "','" + aStaff.Password + "','" + aStaff.JobTitle + "','" + aStaff.FirstName + "','" + aStaff.LastName + "','" + aStaff.Street + "','" + aStaff.Town + "','" + aStaff.Postcode + "','" + aStaff.PhoneNo + "','" + aStaff.Email + "')";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Updates an existing database entry by finding the customer linked to the username
     * 
     * @param aCustomer - The customer being updated in the database
     * */

    public void updateCustomerDetails(Customer aCustomer)
    {
        string sqlQuery = "UPDATE Customers SET FirstName = '" + aCustomer.FirstName + "', LastName = '" + aCustomer.LastName + "', Street = '" + aCustomer.Street + "', Town = '" + aCustomer.Town + "', Postcode = '" + aCustomer.Postcode + "', PhoneNo = '" + aCustomer.PhoneNo + "', Email = '" + aCustomer.Email + "'"
        + "WHERE Username = '" + aCustomer.Username + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Updates an existing database entry by finding the staff member linked to the username
     * 
     * @param aStaff - The staff member being updated in the database
     * */

    public void updateStaffDetails(Staff aStaff)
    {

        string sqlQuery = "UPDATE Staff SET FirstName = '" + aStaff.FirstName + "', LastName = '" + aStaff.LastName + "', Street = '" + aStaff.Street + "', Town = '" + aStaff.Town + "', Postcode = '" + aStaff.Postcode + "', PhoneNo = '" + aStaff.PhoneNo + "', Email = '" + aStaff.Email + "'"
        + "WHERE Username = '" + aStaff.Username + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Updates an existing database entry by finding the product linked to the productId
     * 
     * @param aProduct - The product being updated in the database
     * */

    public void updateProduct(Product aProduct)
    {

        string sqlQuery = "UPDATE Products SET ProductName = '" + aProduct.ProductName + "', Description = '" + aProduct.Description + "', QuantityHeld = '" + aProduct.QuantityHeld + "', ReorderLevel = '" + aProduct.ReorderLevel + "', ReorderQuantity = '" + aProduct.ReorderQuantity + "'"
        + "WHERE ProductId = '" + aProduct.ProductId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Updates an existing database entry by finding the order linked to the orderId
     * 
     * @param aOrder - The order being updated in the database
     * */

    public void updateOrder(Order aOrder)
    {
        string sqlQuery = "UPDATE Orders SET StaffUsername = '" + aOrder.StaffUser + "', Username = '" + aOrder.Username + "', OrderDate = '" + aOrder.OrderDate + "', ShippingPrice = '" + aOrder.ShippingPrice + "', Total = '" + aOrder.Total + "', ShippingStatus = '" + aOrder.ShippingStatus + "' WHERE OrderId = '" + aOrder.OrderId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Updates an existing database entry by finding the productreturn linked to the returnId
     * 
     * @param returnId - The id of the productreturn being updated in the database
     * */

    public void updateProductReturn(string returnId)
    {

        string sqlQuery = "UPDATE ProductReturns SET Approved = '" + true + "' WHERE ReturnId = '" + returnId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
     * Removes the customer linked to the username from the database using the input
     * 
     * @param username - The username of the customer requesting to be removed
     * */

    public void removeCustomer(string username)
    {
        string sqlQuery = "DELETE FROM Customers WHERE Username = '" + username + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
    * Removes the staff member linked to the username from the database using the input
    * 
    * @param username - The username of the staff member requesting to be removed
    * */

    public void removeStaffMember(string username)
    {
        string sqlQuery = "DELETE FROM Staff WHERE Username = '" + username + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
    * Removes the order linked to the orderId from the database using the input
    * Removes all orderlines linked to the order also using the input
    * 
    * @param aOrder - The order object being removed from the database
    * */

    public void removeUserOrder(Order aOrder)
    {
        string sqlQuery = "DELETE FROM Orders WHERE OrderId = '" + aOrder.OrderId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }

        string sqlQuery2 = "DELETE FROM OrderLines WHERE OrderId = '" + aOrder.OrderId + "'";

        SqlConnection myConnection2 = new SqlConnection(connStr);
        SqlCommand myCommand2 = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection2.Open();
            myCommand2.ExecuteNonQuery();
            myConnection2.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
    * Removes the product linked to the productId from the database using the input
    * 
    * @param productId - The productid used to remove the product from the database
    * */

    public void removeProduct(string productId)
    {
        string sqlQuery = "DELETE FROM Products WHERE ProductId = '" + productId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    /*
    * Removes the productreturn linked to the returnId from the database using the input
    * 
    * @param returnId - The returnid used to remove the productreturn from the database
    * */

    public void removeProductReturn(string returnId)
    {
        string sqlQuery = "DELETE FROM ProductReturns WHERE ReturnId = '" + returnId + "'";

        SqlConnection myConnection = new SqlConnection(connStr);
        SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Exception e = ex;
            myConnection.Close();
        }
    }

    public DataAccess()
    {

    }
}