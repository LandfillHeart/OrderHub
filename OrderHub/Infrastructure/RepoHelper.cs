using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure
{
	internal static class RepoHelper
	{
		public static bool IsValueValid(string name)
		{
			return !string.IsNullOrEmpty(name);
		}

		public static bool IsValueValid(float price)
		{
			return price > 0f;
		}
	}
}
