using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure
{
	internal static class ID_Helper
	{
		private static int nextID;
		public static int GetNewID()
		{
			return nextID++;
		}
	}
}
