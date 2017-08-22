using System;
using System.Threading.Tasks;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Portal.Consumer
{
	public class UserCreatedConsumer : IConsumer<IUserCreated>
	{
		public async Task Consume(ConsumeContext<IUserCreated> context)
		{
			await Console.Out.WriteLineAsync("Assigning licenses...");
		}
	}
}
