using OrderHub.Infrastructure.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Infrastructure.MemoryRepos
{
	internal class InMemoryClientRepository : IClientRepository
	{
		#region Singleton
		private static InMemoryClientRepository instance;
		public static InMemoryClientRepository Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new InMemoryClientRepository();
				}
				return instance;
			}
		}
		private InMemoryClientRepository()
		{
			ClientsByID = new Dictionary<int, string>();
		}
		#endregion
		public Dictionary<int, string> ClientsByID { get; private set; }

		public void CreateClient(string name)
		{
			if (!RepoHelper.IsValueValid(name)) return;

			ClientsByID.Add(ID_Helper.GetNewID(), name);
		}

		public void DeleteClient(int id)
		{
			if (!ClientsByID.ContainsKey(ID_Helper.GetNewID())) return;
			ClientsByID.Remove(ID_Helper.GetNewID());
		}

		public string ReadClient(int id)
		{
			if(!ClientsByID.ContainsKey(id))
			{
				throw new ArgumentOutOfRangeException("ID non trovato");
			}

			return ClientsByID[id];
		}

		public void UpdateClient(int id, string newName)
		{
			if (!ClientsByID.ContainsKey(id)) return;
			if (!RepoHelper.IsValueValid(newName)) return;
			ClientsByID[id] = newName;
		}
	}
}
