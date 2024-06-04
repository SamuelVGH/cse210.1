using System;
using System.Collections.Generic;

public class Product
{
    private string name, id;
    private double price;
    private int quantity;

    public Product(string name, string id, double price, int quantity)
    {
        this.name = name; this.id = id;
        this.price = price; this.quantity = quantity;
    }

    public double CalculateTotalCost() => price * quantity;

    public string Name => name;
    public string Id => id;
    public double Price => price;
    public int Quantity => quantity;
}

public class Address
{
    private string street, city, state, country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street; this.city = city;
        this.state = state; this.country = country;
    }

    public bool IsUS() => country.ToLower() == "usa";

    public string GetFullAddress() => $"{street}, {city}, {state}, {country}";
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name; this.address = address;
    }

    public string Name => name;
    public Address Address => address;

    public bool IsUSCustomer() => address.IsUS();
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        products = new List<Product>(); this.customer = customer;
    }

    public void AddProduct(Product product) => products.Add(product);

    public double CalculateTotalCost()
    {
        double totalCost = products.Sum(product => product.CalculateTotalCost());
        totalCost += customer.IsUSCustomer() ? 5 : 35;
        return totalCost;
    }

    public string GetPackagingLabel() => $"Packaging Label:\n{string.Join("\n", products.Select(product => $"- {product.Name} ({product.Id})"))}";

    public string GetShippingLabel() => $"Shipping Label:\nName: {customer.Name}\nAddress: {customer.Address.GetFullAddress()}";
}

class Program
{
    static void Main(string[] args)
    {
        Address customerAddress = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer = new Customer("John Doe", customerAddress);

        Product product1 = new Product("Product 1", "P1", 10.98, 2);
        Product product2 = new Product("Product 2", "P2", 5.99, 3);

        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        Console.WriteLine(order.GetPackagingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}");

        Product product3 = new Product("Product 3", "P3", 7.5, 4);
        Order order2 = new Order(customer);
        order2.AddProduct(product3);

        Console.WriteLine("\nAnother Order:");
        Console.WriteLine(order2.GetPackagingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
