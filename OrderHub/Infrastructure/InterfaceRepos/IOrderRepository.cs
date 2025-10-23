using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure.InterfaceRepos
{
	internal interface IOrderRepository
	{
		public Dictionary<int, string> OrdersByID { get; }
		public void CreateOrder(string newOrder);
		public string ReadOrder(int id);
		public void UpdateOrder(int id, string newOrder);
		public void DeleteOrder(int id);
	}
}
