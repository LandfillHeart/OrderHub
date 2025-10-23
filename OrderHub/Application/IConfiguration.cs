using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application
{
	public interface IConfiguration
	{
		public double TaxRate { get; }
		public string Currency { get; }
		public string Environment { get; }
		public string ApiBaseUrl { get; }
		public string CompanyName { get; }
		public DateTime LoadedAt { get; }
		public bool IsProduction { get; }
	}
}
