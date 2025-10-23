using Domain;
using OrderHub.Application;

namespace Application
{
	#region SINGLETON
	sealed class ConfigurationProvider : IConfiguration
	{
		#region Singleton
		// Lazy + thread-safe
		private static readonly Lazy<ConfigurationProvider> _lazy =
			new Lazy<ConfigurationProvider>(() => new ConfigurationProvider());
		public static ConfigurationProvider Instance => _lazy.Value;
		#region Dependency Injection - Config
		private IConfiguration configuration;
		#endregion

		public double TaxRate => configuration.TaxRate;
		public string Currency => configuration.Currency;
		public string Environment => configuration.Environment;
		public string ApiBaseUrl => configuration.ApiBaseUrl;
		public string CompanyName => configuration.CompanyName;
		public DateTime LoadedAt => configuration.LoadedAt;
		public bool IsProduction => configuration.IsProduction;

		private ConfigurationProvider()
		{
			// avoid null errors, provide default func, possibly serialize default config from user data etc etc
			if (configuration == null)
			{
				configuration = Program.defaultConfig;
			}
		}
		#endregion

		public void SetConfiguration(IConfiguration config)
		{
			this.configuration = config;
		}
	}
	#endregion

	#region FACTORY
	public static class PaymentFactory
	{
		public static IPayment Payment(PaymentType paymentType)
		{
			return paymentType switch
			{
				PaymentType.Card => new CardPayment(),
				PaymentType.PayPal => new PayPalPayment(),
				PaymentType.BankTransfer => new BankTrasferPayment(),
				_ => throw new ArgumentException("Tipo non esistente!")
			};
		}
	}
	#endregion

	#region ENTITA'
	public class CardPayment : IPayment
	{
		private readonly OrderStatus _status;
		public void ProcessPayment(decimal amount)
		{
			if (_status == OrderStatus.New) { Console.WriteLine($"Pagamento effettuato con Carta\timporto: {amount}"); }
			throw new ArgumentException($"Non puoi effettuare il pagamento!\tStato attuale: {_status}");
		}
		public string GetName() { return "Carta"; }

	}
	public class PayPalPayment : IPayment
	{
		private readonly OrderStatus _status;
		public void ProcessPayment(decimal amount)
		{
			if (_status == OrderStatus.New) { Console.WriteLine($"Pagamento effettuato con PayPal\timporto: {amount}"); }
			throw new ArgumentException($"Non puoi effettuare il pagamento!\tStato attuale: {_status}");
		}
		public string GetName() { return "PayPal"; }
	}
	public class BankTrasferPayment : IPayment
	{
		private readonly OrderStatus _status;
		public void ProcessPayment(decimal amount)
		{
			if (_status == OrderStatus.New) { Console.WriteLine($"Pagamento effettuato con Bonifico\timporto: {amount}"); }
			throw new ArgumentException($"Non puoi effettuare il pagamento!\tStato attuale: {_status}");
		}
		public string GetName() { return ""; }
	}
	#endregion
}