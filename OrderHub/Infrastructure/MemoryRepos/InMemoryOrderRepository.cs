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
			OrdersByID = new Dictionary<int, string>();
		}
		#endregion
		public Dictionary<int, string> OrdersByID { get; }

		public void CreateOrder(string newOrder)
		{
			if (!RepoHelper.IsValueValid(newOrder)) return;
			OrdersByID.Add(ID_Helper.GetNewID(), newOrder);
		}

		public void DeleteOrder(int id)
		{
			if (!OrdersByID.ContainsKey(id)) return;
		}

		public string ReadOrder(int id)
		{
			if (!OrdersByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}
			return OrdersByID[id];
		}

		public void UpdateOrder(int id, string newOrder)
		{
			if (!OrdersByID.ContainsKey(id)) return;
			if (!RepoHelper.IsValueValid(newOrder)) return;
			OrdersByID[id] = newOrder;
		}
	}
}
