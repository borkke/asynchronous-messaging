using System.Collections.Generic;
using Masstransit.Shared;

namespace Masstransit.Service.Customer.Command
{
	public class CustomerCreatedCommand : ICustomerCreated
	{
		public CustomerCreatedCommand(string customerName, string userName, List<string> licenses)
		{
			CustomerName = customerName;
			UserName = userName;
			Licenses = licenses;
		}

		public string CustomerName { get; }
		public string UserName { get; }
		public List<string> Licenses { get; }
	}
}
