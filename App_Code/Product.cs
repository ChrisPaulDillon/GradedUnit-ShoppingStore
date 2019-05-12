using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class Product
{
    private string productId;
    private string productName;
    private string description;
    private decimal unitPrice;
    private int quantityHeld;
    private int reorderLevel;
    private int reorderQuantity;
    private string imgPath;

    public string ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public decimal UnitPrice
    {
        get { return unitPrice; }
        set { unitPrice = value; }
    }

    public int QuantityHeld
    {
        get { return quantityHeld; }
        set { quantityHeld = value; }
    }

    public int ReorderLevel
    {
        get { return reorderLevel; }
        set { reorderLevel = value; }
    }

    public int ReorderQuantity
    {
        get { return reorderQuantity; }
        set { reorderQuantity = value; }
    }

    public string ImgPath
    {
        get { return imgPath; }
        set { imgPath = value; }
    }

    public Product()
    {
        productId = "";
        productName = "";
        description = "";
        unitPrice = 0.00M;
        quantityHeld = 0;
        reorderLevel = 0;
        reorderQuantity = 0;
        imgPath = "";
    }

    public Product(string ProductId, string ProductName, string Description, decimal Price, int QuantityHeld, int ReorderLevel, int ReorderQuantity, string ImgPath)
    {
        productId = ProductId;
        productName = ProductName;
        description = Description;
        unitPrice = Price;
        quantityHeld = QuantityHeld;
        reorderLevel = ReorderLevel;
        reorderQuantity = ReorderQuantity;
        imgPath = ImgPath;
    }

    public Product(string ProductId, string ProductName, string Description, decimal Price, int QuantityHeld, int ReorderLevel, int ReorderQuantity)
    {
        productId = ProductId;
        productName = ProductName;
        description = Description;
        unitPrice = Price;
        quantityHeld = QuantityHeld;
        reorderLevel = ReorderLevel;
        reorderQuantity = ReorderQuantity;
        imgPath = null;
    }

    /**
     * Used to check and update details of a product
     * 
     * @param ProductName - The name of the product
     * @param Description - The description of the product
     * @param Price - The price of the product
     * @param QuantityHeld - The amount of stock available for the product
     * @param ReorderLevel - The reorder level of the product
     * @paran ReorderQuantity - The amount to reorder each time
     * 
     * */
    public void checkDetails(string ProductName, string Description, decimal Price, int QuantityHeld, int ReorderLevel, int ReorderQuantity)
    {
        if (ProductName != "")
        {
            productName = ProductName;
        }
        if (Description != "")
        {
            description = Description;
        }
        if (Price != 0)
        {
            unitPrice = Price;
        }
        if (QuantityHeld != 0)
        {
            quantityHeld = QuantityHeld;
        }
        if (ReorderLevel != 0)
        {
            reorderLevel = ReorderLevel;
        }
        if (ReorderQuantity != 0)
        {
            reorderQuantity = ReorderQuantity;
        }
    }
}