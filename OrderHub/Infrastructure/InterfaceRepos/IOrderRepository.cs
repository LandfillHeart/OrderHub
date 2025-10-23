using Domain;

namespace OrderHub.Infrastructure.InterfaceRepos
{
	internal interface IOrderRepository
	{
		public Dictionary<Guid, Order> OrdersByID { get; }
		public void CreateOrder(Order newOrder);
		public Order ReadOrder(Guid id);
		public void UpdateOrder(Guid id, Order newOrder);
		public void DeleteOrder(Guid id);
	}
}
