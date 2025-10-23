using Domain;
using OrderHub.Infrastructure.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application
{
	public class ProductFactory
	{
		private readonly IProductRepository _productRepository;
		private int _nextId = 1;

		public ProductFactory(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public void CreateProduct(string name, decimal price)
		{
			var product = new Product(_nextId++, name, price);
			_productRepository.CreateProduct(product);
			Console.WriteLine($"Prodotto '{name}'");
		}

		public List<Product> GetAllProducts()
		{
			return _productRepository.GetAll();
		}

		public Product GetProductById(int id)
		{
			return _productRepository.ReadProduct(id);
		}
	}
}
