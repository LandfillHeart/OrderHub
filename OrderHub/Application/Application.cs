using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{

    using Domain;
    using Infrastructure;


    sealed class ConfigurationProvider
    {
        // Lazy + thread-safe
        private static readonly Lazy<ConfigurationProvider> _lazy =
            new Lazy<ConfigurationProvider>(() => new ConfigurationProvider());
        public static ConfigurationProvider Instance => _lazy.Value;
        public double TaxRate { get; private set; }
        public string Currency { get; private set; }
        public string Environment { get; private set; }
        public string ApiBaseUrl { get; private set; }
        public string CompanyName { get; private set; }
        public DateTime LoadedAt { get; private set; }
        public bool IsProduction{ get; private set; }

        private ConfigurationProvider()
        {
            Currency = "EUR";
            TaxRate = Currency == "EUR" ? 0.22 : 0.10;
            Environment = "Demo";
            ApiBaseUrl = "https://api.orderhub.local";
            CompanyName = "OrderHub S.r.l.";
            LoadedAt = DateTime.UtcNow; //UtcNow sono le coordinate attuali configurate nel pc
            IsProduction = Environment == "Demo" ? false : true;
        }
    }


    
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private int _nextId = 1;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void CreateProduct(string name, decimal price)
        {
            var product = new Product(_nextId++, name, price);
            _productRepository.Add(product);
            Console.WriteLine($"Prodotto '{name}'");
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }
    }

}