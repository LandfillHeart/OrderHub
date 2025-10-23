using Domain;

namespace OrderHub.Infrastructure
{
	internal static class RepoHelper
	{
		public static bool IsValid(Order order)
		{
			if (order == null) return false;
			return true;
		}

		public static bool IsValid(Product product)
		{
			if (product == null) return false;
			if (string.IsNullOrEmpty(product.Name)) return false;
			if (product.Price <= 0) return false;
			return true;
		}

		public static bool IsValueValid(string name)
		{
			return !string.IsNullOrEmpty(name);
		}

		public static bool IsValueValid(decimal price)
		{
			return price > 0;
		}
	}
}
