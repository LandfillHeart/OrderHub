using Domain;

namespace OrderHub.Infrastructure.InterfaceRepos
{
	internal interface IClientRepository
	{
		public Dictionary<int, string> ClientsByID { get; }
		public void CreateClient(string name);
		public string ReadClient(int id);
		public void UpdateClient(int id, string name);
		public void DeleteClient(int id);
	}
}
