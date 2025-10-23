using OrderHub.Infrastructure.InterfaceRepos;
using OrderHub.Application;
using Domain;

namespace OrderHub.Application
{
	public class OrderFactory
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly IConfiguration _config;

		public event OrderEventHandler OnOrderPaid;
		public event OrderEventHandler OnOrderShipped;

		public OrderFactory(
			IOrderRepository orderRepository,
			IProductRepository productRepository,
			IConfiguration config)
		{
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_config = config;
		}

		public Order CreateOrder(string customerName)
		{
			var order = new Order(customerName);
			_orderRepository.CreateOrder(order);
			Console.WriteLine($"Ordine {order.Id} creato da ");
			return order;
		}
	}
}

