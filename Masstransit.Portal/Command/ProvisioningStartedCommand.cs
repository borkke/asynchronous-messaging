using System.Collections.Generic;
using Masstransit.Shared;

namespace Masstransit.Portal.Command
{
	public class ProvisioningStartedCommand : IProvisioningStarted
	{
		public ProvisioningStartedCommand(string customerName, string username, List<string> licenses)
		{
			CustomerName = customerName;
			UserName = username;
			Licenses = licenses;
		}

		public string CustomerName { get; set; }
		public string UserName { get; set; }
		public List<string> Licenses { get; set; }
	}
}
