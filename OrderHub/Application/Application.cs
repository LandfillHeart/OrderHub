using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHub.Application
{
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
}