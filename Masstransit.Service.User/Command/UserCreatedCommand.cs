using System.Collections.Generic;
using Masstransit.Shared;

namespace Masstransit.Service.User.Command
{
	public class UserCreatedCommand : IUserCreated
	{
		public UserCreatedCommand(string customerName, string username, List<string> licenses)
		{
			CustomerName = customerName;
			UserName = username;
			Licenses = licenses;
		}

		public string CustomerName { get; }
		public string UserName { get; }
		public List<string> Licenses { get; }
	}
}
