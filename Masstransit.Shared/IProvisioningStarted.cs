using System.Collections.Generic;

namespace Masstransit.Shared
{
	public interface IProvisioningStarted
	{
		string CustomerName { get; }
		string UserName { get; }
		List<string> Licenses { get; }
	}
}
