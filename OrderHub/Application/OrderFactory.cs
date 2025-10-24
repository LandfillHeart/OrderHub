using OrderHub.Infrastructure.InterfaceRepos;
using OrderHub.Application;
using Domain;

namespace OrderHub.Application
{
	public class OrderFactory
	{
		private readonly IOrderRepository _orderRepository;

		public event OrderEventHandler OnOrderPaid;
		public event OrderEventHandler OnOrderShipped;

		public OrderFactory(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public Order CreateOrder(string customerName)
		{
			var order = new Order(customerName);
			_orderRepository.CreateOrder(order);
			Console.WriteLine($"Ordine {order.Id} creato da {customerName}");
			return order;
		}
	}
}

