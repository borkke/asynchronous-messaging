using System.Collections.Generic;
using Masstransit.Shared;

namespace Masstransit.Service.Licensing.Command
{
	public class LicensingFinishedCommand : ILicensingFinished
	{
		public LicensingFinishedCommand(string customerName, string username, List<string> licenses)
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
