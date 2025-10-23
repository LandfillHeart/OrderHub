using Domain;
using OrderHub.Infrastructure.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application
{
	public class ApplicationLayer
	{
		#region Singleton
		private static ApplicationLayer instance;
		public static ApplicationLayer Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new ApplicationLayer();
				}
				return instance;
			}
		}
		private ApplicationLayer() { }
		#endregion

		// setter injection - cant initialize at ctr with singleton
		#region Dependency Injection
		private IProductRepository productRepository;
		private IOrderRepository orderRepository;

		public void InitializeProductRepo(IProductRepository repo)
		{
			productRepository = repo;
			productFactory = new ProductFactory(repo);
		}

		public void InitializeOrderFactory(IOrderRepository repo)
		{
			orderRepository = repo;
			orderFactory = new OrderFactory(repo);
		}
		#endregion

		private OrderFactory orderFactory;
		private ProductFactory productFactory;

		// read configs
		// CRUD - Product
		public void CreateProduct(string name, decimal price)
		{
			if(productRepository == null)
			{
				Console.WriteLine("Nessun accesso ad una repo di prodotti");
				return;
			}

			// this pushes directly into the repo
			productFactory.CreateProduct(name, price);
		}

		public bool GetAllProducts(out List<Product> toReturn)
		{
			if(productRepository == null)
			{
				toReturn = new List<Product>();
				return false;
			}

			toReturn = productRepository.GetAll();
			return true;
		}

		public bool GetProduct(int prodID, out Product toReturn)
		{
			if(productRepository == null)
			{
				toReturn = null;
				return false;
			}

			toReturn = productRepository.ReadProduct(prodID);
			return true;
		}
		// CRUD - Orders

	}
}
