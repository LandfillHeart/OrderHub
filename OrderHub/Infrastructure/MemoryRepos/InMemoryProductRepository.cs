using Domain;
using OrderHub.Infrastructure.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure.MemoryRepos
{
	internal class InMemoryProductRepository : IProductRepository
	{
		#region Singleton
		private static InMemoryProductRepository instance;
		public static InMemoryProductRepository Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new InMemoryProductRepository();
				}
				return instance;
			}
		}
		private InMemoryProductRepository()
		{
			ProductsByID = new Dictionary<int, Product>();
		}
		#endregion

		public Dictionary<int, Product> ProductsByID { get; private set; }

		public void CreateProduct(Product newProduct)
		{
			// TODO: add a result message 
			if (!RepoHelper.IsValid(newProduct)) return;

			ProductsByID.Add(newProduct.Id, newProduct);
		}

		public Product ReadProduct(int id)
		{
			if (!ProductsByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}
			return ProductsByID[id];
		}

		public void RemoveProduct(int id)
		{
			if (!ProductsByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}

			ProductsByID.Remove(id);
		}

		public void UpdateProduct(int id, string newName, decimal newPrice)
		{
			// TODO: add a result message
			if (!ProductsByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}

			if (!RepoHelper.IsValueValid(newName) || !RepoHelper.IsValueValid(newPrice)) return;

			ProductsByID[id].Name = newName;
			ProductsByID[id].Price = newPrice;
		}

		public List<Product> GetAll()
		{
			return ProductsByID.Values.ToList();
		}
	}
}
