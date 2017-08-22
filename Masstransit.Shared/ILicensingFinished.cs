using System.Collections.Generic;

namespace Masstransit.Shared
{
	public interface ILicensingFinished
	{
		string CustomerName { get; }
		string UserName { get; }
		List<string> Licenses { get; }
	}
}
