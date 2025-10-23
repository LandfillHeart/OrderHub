using System;
using System.Collections.Generic;
using System.Linq;

namespace  Domain
{
    public enum PaymentType { Card, PayPal, BankTransfer }
    public enum OrderStatus { New, Paid, Shipped, Cancelled }

    public delegate void OrderEventHandler(Guid orderId, decimal total);

    public class Product
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public decimal Price {get;set;}

        public Product (int id, string name, decimal price)
        {
            Id= id;
            Name=name;
            Price=price;
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetSubtotal()
        {
            return Product.Price * Quantity;
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public Order(string customerName)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            Items = new List<OrderItem>();
            Status = OrderStatus.New;
            CreatedAt = DateTime.Now;
        }

        public void AddItem(Product product, int quantity)
        {
            Items.Add(new OrderItem(product, quantity));
        }

        public void CalculateTotals(decimal taxRate)
        {
            Subtotal = Items.Sum(item => item.GetSubtotal());
            Tax = Subtotal * taxRate;
            Total = Subtotal + Tax;
        }
    }

    public interface IPayment
    {
        void ProcessPayment(decimal amount);
        string GetName();
    }

    public interface INotifier
    {
        void Notify(string message);
    }

    public interface IConfigurationProvider
    {
        decimal TaxRate { get; }
        string Currency { get; }
        string Environment { get; }
    }
}





