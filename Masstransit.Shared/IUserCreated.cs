using System.Collections.Generic;

namespace Masstransit.Shared
{
	public interface IUserCreated
	{
		string CustomerName { get; }
		string UserName { get; }
		List<string> Licenses { get; }
	}
}
