using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    public string Name { get; }
    public string ProductId { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }
}

public class Customer
{
    public string Name { get; }
    public Address Address { get; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

public class Address
{
    private string Street { get; }
    private string City { get; }
    private string State { get; }
    private string Country { get; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

public class Order
{
    private List<Product> Products { get; } = new List<Product>();
    private Customer Customer { get; }
    private const decimal ShippingCostUSA = 5.0m;
    private const decimal ShippingCostInternational = 35.0m;

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0.0m;
        foreach (var product in Products)
        {
            totalCost += product.GetTotalCost();
        }
        totalCost += Customer.IsInUSA() ? ShippingCostUSA : ShippingCostInternational;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (var product in Products)
        {
            sb.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.Name}\n{Customer.Address}";
    }
}

class Program
{
    static void Main()
    {
        // Create products
        Product product1 = new Product("Laptop", "LAP123", 999.99m, 1);
        Product product2 = new Product("Mouse", "MOU456", 19.99m, 2);
        Product product3 = new Product("Keyboard", "KEY789", 49.99m, 1);

        // Create customers with addresses
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Anytown", "CA", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Othertown", "ON", "Canada"));

        // Create orders and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order.CalculateTotalCost():C2}");
        Console.WriteLine(new string('-', 30));
    }
}
