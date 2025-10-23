using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure.InterfaceRepos
{
	internal interface IProductRepository
	{
		public Dictionary<int, string> ProductsByID { get; }
		public void CreateProduct(string productName, float productPrice);
		public string ReadProduct(int id);
		public void UpdateProduct(int id, string newName, float newPrice);
		public void RemoveProduct(int id);
	}
}
