using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure
{
	internal class InMemoryProductRepository : IProductRepository
	{
		// TODO: await domain contents to then couple with either types or interfaces
		public Dictionary<int, string> ProductsByID { get; private set; }

		public void CreateProduct(string productName, float productPrice)
		{
			// TODO: add a result message 
			if (!IsValueValid(productName) || !IsValueValid(productPrice)) return;

			ProductsByID.Add(ID_Helper.GetNewID(), productName);
		}

		public string ReadProduct(int id)
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

		public void UpdateProduct(int id, string newName, float newPrice)
		{
			// TODO: add a result message
			if (!ProductsByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}

			if (!IsValueValid(newName) || !IsValueValid(newPrice)) return;

			ProductsByID[id] = newName;
		}

		private bool IsValueValid(string name)
		{
			return !string.IsNullOrEmpty(name);
		}

		private bool IsValueValid(float price)
		{
			return price > 0f;
		}
	}
}
