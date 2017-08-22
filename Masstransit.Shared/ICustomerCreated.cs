using System.Collections.Generic;

namespace Masstransit.Shared
{
	public interface ICustomerCreated
	{
		string CustomerName { get; }
		string UserName { get; }
		List<string> Licenses { get; }
	}
}
