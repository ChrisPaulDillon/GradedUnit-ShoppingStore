using System.ComponentModel.DataAnnotations;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class OrderLine
{
    private string orderLineId;
    private string orderId;
    private string productId;
    private int quantity;
    private Product product;

    public string OrderLineId
    {
        get { return orderLineId; }
        set { orderLineId = value; }
    }

    public string OrderId
    {
        get { return orderId; }
        set { orderId = value; }
    }

    public string ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Product Product
    {
        get { return product; }
        set { product = value; }
    }

    public OrderLine(string OrderLineId, string OrderId, string ProductId, int Quantity)
    {
        orderLineId = OrderLineId;
        orderId = OrderId;
        productId = ProductId;
        quantity = Quantity;
        product = null;
    }

    public OrderLine()
    {
        orderLineId = "";
        orderId = "";
        productId = "";
        quantity = 0;
    }

    //Adds a product object to the orderline

    public void addProduct(Product aProduct)
    {
        if (product == null)
        {
            product = aProduct;
        }
    }
}