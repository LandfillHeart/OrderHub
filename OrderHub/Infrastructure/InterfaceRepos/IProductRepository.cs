using Domain;

namespace OrderHub.Infrastructure.InterfaceRepos
{
	internal interface IProductRepository
	{
		public Dictionary<int, Product> ProductsByID { get; }
		public void CreateProduct(Product product);
		public Product ReadProduct(int id);
		public void UpdateProduct(int id, string newName, decimal newPrice);
		public void RemoveProduct(int id);
	}
}
