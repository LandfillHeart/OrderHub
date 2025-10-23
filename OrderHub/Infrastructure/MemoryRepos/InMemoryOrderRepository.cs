using Domain;
using OrderHub.Infrastructure.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure.MemoryRepos
{
	internal class InMemoryOrderRepository : IOrderRepository
	{
		#region Singleton
		private static InMemoryOrderRepository instance;
		public static InMemoryOrderRepository Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new InMemoryOrderRepository();
				}
				return instance;
			}
		}
		private InMemoryOrderRepository()
		{
			OrdersByID = new Dictionary<Guid, Order>();
		}
		#endregion
		public Dictionary<Guid, Order> OrdersByID { get; }

		public void CreateOrder(Order newOrder)
		{
			if (!RepoHelper.IsValid(newOrder)) return;
			OrdersByID.Add(newOrder.Id, newOrder);
		}

		public void DeleteOrder(Guid id)
		{
			if (!OrdersByID.ContainsKey(id)) return;
		}

		public Order ReadOrder(Guid id)
		{
			if (!OrdersByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}
			return OrdersByID[id];
		}

		public void UpdateOrder(Guid id, Order newOrder)
		{
			if (!OrdersByID.ContainsKey(id)) return;
			if (!RepoHelper.IsValid(newOrder)) return;
			OrdersByID[id] = newOrder;
		}
	}
}
