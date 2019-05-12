using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class Shop
{
    private Dictionary<string, Staff> shopStaff;
    private Dictionary<string, Customer> shopCustomers;
    private Dictionary<string, Product> shopProducts;
    private Dictionary<string, ProductReturn> shopProductReturns;
    private Dictionary<string, Location> shopLocations;
    DataAccess dbAccess = new DataAccess();

    public Dictionary<string, Staff> ShopStaff
    {
        get { return shopStaff; }
        set { shopStaff = value; }
    }

    public Dictionary<string, Customer> ShopCustomers
    {
        get { return shopCustomers; }
        set { shopCustomers = value; }
    }

    public Dictionary<string, Product> ShopProducts
    {
        get { return shopProducts; }
        set { shopProducts = value; }
    }

    public Dictionary<string, ProductReturn> ShopProductReturns
    {
        get { return shopProductReturns; }
        set { shopProductReturns = value; }
    }

    public Dictionary<string, Location> ShopLocations
    {
        get { return shopLocations; }
        set { shopLocations = value; }
    }

    public Shop()
    {
        shopStaff = new Dictionary<string, Staff>();
        shopCustomers = new Dictionary<string, Customer>();
        shopProducts = new Dictionary<string, Product>();
        shopProductReturns = new Dictionary<string, ProductReturn>();
        shopLocations = new Dictionary<string, Location>();
        shopCustomers = dbAccess.loadCustomers();
        shopStaff = dbAccess.loadStaff();
        shopProducts = dbAccess.loadProducts();
        shopProductReturns = dbAccess.loadProductReturns();
        shopLocations = dbAccess.loadLocations();
    }

    /**
     * Used to check login information when signing up.
     * Checks for the username already being in use,
     * the email address already being in use,
     * and the passwords matching as well as being valid.
     * 
     * @param username - The username being input by the user
     * @param password-  The password being input by the user
     * @param passConfirm - The password confirm being input by the user
     * @param email - The email address being input by the user
     * @return - The warning message if any value is invalid
     * */

    public string checkCredientials(string username, string password, string passConfirm, string email)
    {
        string message = "";

        foreach (KeyValuePair<string, Customer> curCustomer in shopCustomers)
        {
            if (username.ToLower() == curCustomer.Value.Username)
            {
                return message = "Username already in use!";
            }

            if (email.Length > 1)
            {
                if (email.ToLower() == curCustomer.Value.Email)
                {
                    return message = "Email already in use!";
                }
            }
        }

        if (username.Length < 1)
        {
            return message = "Username field cannot be empty!";
        }
        if (password.Length < 6)
        {
            return message = "Password must be at least 6 characters long!";
        }

        if (password != passConfirm)
        {
            return message = "Passwords do not match!";
        }
        return "";
    }

    //Login methods

    /**
     * Used for logging in a staff member 
     * Checks if the username is found and is the correct password
     * 
     * @param user - The username being input from the user
     * @param password - The password being input from the user
     * @return - Returns if the username was found and the password was correct or not
     * */

    public bool staffLogin(string user, string password)
    {
        bool isFound = false;
        foreach (KeyValuePair<string, Staff> curStaff in shopStaff)
        {
            if (curStaff.Value.Username == user &&
                curStaff.Value.Password == password)
            {
                isFound = true;
            }
        }
        return isFound;
    }

    /**
   * Used for logging in a customer member 
   * Checks if the username is found and the correct password is being input
   * 
   * @param user - The username being input from the user
   * @param password - The password being input from the user
   * @return - Returns if the username was found and the password was correct or not
   * */

    public bool customerLogin(string user, string password)
    {
        bool isFound = false;
        foreach (KeyValuePair<string, Customer> curCustomer in shopCustomers)
        {
            if (curCustomer.Value.Username == user &&
                curCustomer.Value.Password == password)
            {
                isFound = true;
            }
        }
        return isFound;
    }

    //Get object methods

    /**
     * Used to get the Staff object based on the Id
     * and will return that object if it exists within the dictionary
     * 
     * @param user - The username being input from the user
     * @param password - The password being input from the user
     * @return - Returns the Staff object retrieved
     * */

    public Staff getStaff(string user, string password)
    {
        foreach (KeyValuePair<string, Staff> curStaff in shopStaff)
        {
            if (curStaff.Value.Username == user &&
                curStaff.Value.Password == password)
            {
                return curStaff.Value;
            }
        }
        return null;
    }

   /**
    * Used to get the Customer object based on the Id
    * and will return that object if it exists within the dictionary
    * 
    * @param user - The username being input from the user
    * @return - Returns the Staff object retrieved
    * */

    public Staff getStaff(string user)
    {
        foreach (KeyValuePair<string, Staff> curStaff in shopStaff)
        {
            if (curStaff.Value.Username == user)
            {
                return curStaff.Value;
            }
        }
        return null;
    }

    /**
     * Used to get the Customer object based on the Id
     * and will return that object if it exists within the dictionary
     * 
     * @param user - The username being input from the user
     * @param password - The password being input from the user
     * @return - Returns the Customer object retrieved
     * */

    public Customer getCustomer(string user, string password)
    {
        Customer aCustomer = new Customer();
        foreach (KeyValuePair<string, Customer> curCustomer in shopCustomers)
        {
            if (curCustomer.Value.Username == user &&
                curCustomer.Value.Password == password)
            {
                aCustomer = curCustomer.Value;
            }
        }
        return aCustomer;
    }

    /**
     * Used to get the Customer object based on the Id
     * and will return that object if it exists within the dictionary
     * 
     * @param user - The Id being input from the user
     * @return - The Customer object found with the corresponding id
     * 
     * */

    public Customer getCustomer(string user) 
    {
        Customer aCustomer = new Customer();
        foreach (KeyValuePair<string, Customer> curCustomer in shopCustomers)
        {
            if (curCustomer.Value.Username == user)
            {
                aCustomer = curCustomer.Value;
            }
        }
        return aCustomer;
    }

    /**
     * Used to get the Product object based on the Id
     * and will return that object if it exists within the dictionary
     * 
     * @param productId - The Id being input from the user
     * @return - The Product object found with the corresponding id
     * */

    public Product GetProduct(string productId)
    {
        foreach (KeyValuePair<string, Product> curProduct in shopProducts)
        {
            if (curProduct.Value.ProductId == productId)
            {
                return curProduct.Value;
            }
        }
        return null;
    }

    /**
      * Used to get the ProductReturn object based on the Id
      * and will return that object if it exists within the dictionary
      *   
      * @param returnId - The Id being input from the user
      * @return - The ProductReturn object found with the corresponding id
      * */

    public ProductReturn GetProductReturn(string returnId)
    {
        foreach (KeyValuePair<string, ProductReturn> curProduct in shopProductReturns)
        {
            if (curProduct.Value.ReturnId == returnId)
            {
                return curProduct.Value;
            }
        }
        return null;
    }

    //Add methods

    /*
     * Adds a new Customer object to the shopCustomers dictionary
     * if the username does not exist
     * 
     * @param aCustomer - The Customer object being added to the dictionary      
     * */

    public void addCustomer(Customer aCustomer)
    {
        if (!shopCustomers.ContainsKey(aCustomer.Username))
        {
            shopCustomers.Add(aCustomer.Username, aCustomer);
            dbAccess.addCustomer(aCustomer);
        }
    }

    /*
     * Adds a new Staff object to the shopStaff dictionary
     * if the username does not exist
     * 
     * @param aStaff - The Staff object being added to the dictionary      
     * */

    public void addStaff(Staff aStaff)
    {
        if (!shopStaff.ContainsKey(aStaff.Username))
        {
            shopStaff.Add(aStaff.Username, aStaff);
            dbAccess.addStaff(aStaff);
        }
    }

    /*
     * Adds a new Product object to the shopProducts dictionary
     * if the productId does not exist
     * 
     * @param aProduct - The Product object being added to the dictionary      
     * */

    public void addProduct(Product aProduct)
    {
        if (!shopProducts.ContainsKey(aProduct.ProductId))
        {
            shopProducts.Add(aProduct.ProductId, aProduct);
            dbAccess.addProduct(aProduct);
        }
    }

    /*
    * Adds a new ProductReturn object to the shopProductsReturns dictionary
    * if the returnId does not exist
    * 
    * @param aProduct - The Product object being added to the dictionary      
    * */

    public void addProductReturn(ProductReturn aProductReturn)
    {
        if (!shopProductReturns.ContainsKey(aProductReturn.ProductId))
        {
            shopProductReturns.Add(aProductReturn.ReturnId, aProductReturn);
            dbAccess.addProductReturn(aProductReturn);
        }
    }

    //Update Methods

    /*
     * Used to update Customer details. 
     * Checks if the customer is found and then replaces the previous Customer object
     * with the updated version
     * 
     * @param aCustomer - The Customer object with the updated values
     * */

    public void updateCustomerDetails(Customer aCustomer)
    {
        foreach (KeyValuePair<string, Customer> curCustomer in shopCustomers.ToList())
        {
            if (aCustomer.Username == curCustomer.Value.Username)
            {
                shopCustomers[curCustomer.Key] = aCustomer;
                dbAccess.updateCustomerDetails(aCustomer);
            }
        }
    }

    /*
     * Used to update Staff details. 
     * Checks if the staff is found and then replaces the previous Staff object
     * with the updated version
     * 
     * @param aStaff - The Staff object with the updated values
     * */

    public void updateStaffDetails(Staff aStaff)
    {
        foreach (KeyValuePair<string, Staff> curStaffMember in shopStaff.ToList())
        {
            if (aStaff.Username == curStaffMember.Value.Username)
            {
                shopStaff[curStaffMember.Key] = aStaff;
                dbAccess.updateStaffDetails(aStaff);
            }
        }
    }

    /*
     * Used to update Product details. 
     * Checks if the product is found and then replaces the previous Product object
     * with the updated version
     * 
     * @param aProduct - The Product object with the updated values
     * */

    public void updateProduct(Product aProduct)
    {
        foreach (KeyValuePair<string, Product> curProduct in shopProducts.ToList())
        {
            if (aProduct.ProductId == curProduct.Value.ProductId)
            {
                shopProducts[curProduct.Key] = aProduct;
                dbAccess.updateProduct(aProduct);
            }
        }
    }

    /*
     * Used to update ProductReturn details. 
     * Checks if the ProductReturn is found and then replaces the previous ProductReturn object
     * with the updated version
     * 
     * @param aProduct - The ProductReturn object with the updated values
     * */

    public void updateProductReturn(ProductReturn aProductReturn)
    {
        foreach (KeyValuePair<string, ProductReturn> curProduct in shopProductReturns.ToList())
        {
            if (aProductReturn.ReturnId == curProduct.Value.ReturnId)
            {
                shopProductReturns[curProduct.Key] = aProductReturn;
                dbAccess.updateProductReturn(aProductReturn.ReturnId);
            }
        }
    }
    

    //Remove methods

    /*
     * Used to remove a product by id. Checks if the id is found 
     * in the dictionary, if found the product will be removed
     * 
     * @param id - The id of the product being removed
     * */

    public void removeProduct(string id)
    {
        if (shopProducts.ContainsKey(id)) 
        {
            shopProducts.Remove(id);
            dbAccess.removeProduct(id);
        }
    }

    /*
     * Used to remove a ProductReturn by id. Checks if the id is found 
     * in the dictionary, if found the ProductReturn will be removed
     * 
     * @param id - The id of the ProductReturn being removed
     * */

    public void removeProductReturn(string id)
    {
        if (shopProductReturns.ContainsKey(id))
        {
            shopProductReturns.Remove(id);
            dbAccess.removeProductReturn(id);
        }
    }

    /*
     * Used to remove a Customer by id. Checks if the id is found 
     * in the dictionary, if found the Customer will be removed
     * 
     * @param id - The id of the Customer being removed
     * */

    public void removeCustomer(string id)
    {
        if (shopCustomers.ContainsKey(id)) 
        {
            shopCustomers.Remove(id);
            dbAccess.removeCustomer(id);
        }
    }

    /*
     * Used to remove a Staff member by id. Checks if the id is found 
     * in the dictionary, if found the staff member will be removed.
     * 
     * @param id - The id of the staff member being removed
     * */

    public void removeStaffMember(string id)
    {
        if (shopStaff.ContainsKey(id)) 
        {
            shopStaff.Remove(id);
            dbAccess.removeStaffMember(id);
        }
    }

    //Dictionary methods

    /*
    * Used to get all products which are contained in the string input.
    * Checks each individual product for if the name is contained in the string
    * input and adds it to the local dictionary if true.
    * 
    * @param input - The string used for the search result
    * @return searchProducts - A Dictionary used to hold all products from the search result
    * */

    public Dictionary<string, Product> searchProducts(string input)
    {
        Dictionary<string, Product> searchProducts;
        searchProducts = new Dictionary<string, Product>();

        foreach (KeyValuePair<string, Product> curProduct in shopProducts)
        {
            if (curProduct.Value.ProductName.ToLower().Contains(input.ToLower()))
            {
                searchProducts.Add(curProduct.Value.ProductId, curProduct.Value);
            }
        }
        return searchProducts;
    }

    /*
    * Used to get all customers which are contained in the string input.
    * Checks each individual customer for if the name is contained in the string
    * input and adds it to the local dictionary if true.
    * 
    * @param input - The string used for the search result
    * @return searchCustomers - A Dictionary used to hold all customers from the search result
     * 
    * */

    public Dictionary<string, Customer> searchCustomers(string input)
    {
        Dictionary<string, Customer> searchCustomers;
        searchCustomers = new Dictionary<string, Customer>();

        foreach (KeyValuePair<string, Customer> curCustomer in shopCustomers)
        {
            if (curCustomer.Value.Username.ToLower().Contains(input.ToLower()))
            {
                searchCustomers.Add(curCustomer.Value.Username, curCustomer.Value);
            }
        }
        return searchCustomers;
    }

    /*
    * Used to get all staff which are contained in the string input.
    * Checks each individual staff for if the name is contained in the string
    * input and adds it to the local dictionary if true.
    * 
    * @param input - The string used for the search result
    * @return searchStaff - A Dictionary used to hold all staff from the search result
    * */

    public Dictionary<string, Staff> searchStaff(string input)
    {
        Dictionary<string, Staff> searchStaff;
        searchStaff = new Dictionary<string, Staff>();

        foreach (KeyValuePair<string, Staff> curStaff in shopStaff)
        {
            if (curStaff.Value.Username.ToLower().Contains(input.ToLower()))
            {
                searchStaff.Add(curStaff.Value.Username, curStaff.Value);
            }
        }
        return searchStaff;
    }

    /*
     * Used to get all products under their own individual reorder level.
     * Checks each individual product for if the quantity held is lower than
     * the reorder level. If true it will add the product to the local dictionary.
     * 
     * @return lowStockProducts - A Dictionary used to hold all products currently low in stock
     * */

    public Dictionary<string, Product> getLowStockProducts()
    {
        Dictionary<string, Product> lowStockProducts;
        lowStockProducts = new Dictionary<string, Product>();

        foreach (KeyValuePair<string, Product> curProduct in shopProducts)
        {
            if (curProduct.Value.QuantityHeld < curProduct.Value.ReorderLevel)
            {
                lowStockProducts.Add(curProduct.Value.ProductId, curProduct.Value);
            }
        }
        return lowStockProducts;
    }

    /*
    * Used to get the product contained in the input. Checks each individual product 
    * for if the id is equal to an id in the dictionary. If true it will add it to
    * the local dictionary.
    * 
    * @param input - The string used for the search result
    * @return productDetail - A Dictionary used to hold the prodcut from the search result
    * */

    public Dictionary<string, Product> getProductDetails(string input)
    {
        Dictionary<string, Product> productDetail;
        productDetail = new Dictionary<string, Product>();

        foreach (KeyValuePair<string, Product> curProduct in shopProducts)
        {
            if (curProduct.Value.ProductId == input)
            {
                productDetail.Add(curProduct.Value.ProductId, curProduct.Value);
            }
        }
        return productDetail;
    }

    /*
     * Used to update stock based on the users purchase. Searches through the cart
     * and finds the matching product and then updates the quantity
     * 
     * @param orderCart - The cart being used to update the stock
     * */

    public void updateStock(Dictionary<string, OrderLine> orderCart)
    {
        foreach (KeyValuePair<string, OrderLine> curCartItem in orderCart.ToList())
        {
            foreach (KeyValuePair<string, Product> curProduct in ShopProducts.ToList())
            {
                if (curCartItem.Value.ProductId == curProduct.Value.ProductId)
                {
                    curProduct.Value.QuantityHeld = (curProduct.Value.QuantityHeld - curCartItem.Value.Quantity);
                    updateProduct(curProduct.Value);
                }
            }
        }
    }
}