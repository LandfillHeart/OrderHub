using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application
{
	internal class EU_Config : IConfiguration
	{
		public double TaxRate { get; private set; }

		public string Currency { get; private set; }

		public string Environment { get; private set; }

		public string ApiBaseUrl { get; private set; }

		public string CompanyName { get; private set; }

		public DateTime LoadedAt { get; private set; }

		public bool IsProduction { get; private set; }

		public EU_Config()
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
}
