using System;
using System.Threading.Tasks;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Portal.Consumer
{
	public class CustomerCreatedConsumer : IConsumer<ICustomerCreated>
	{
		public async Task Consume(ConsumeContext<ICustomerCreated> context)
		{
			await Console.Out.WriteLineAsync("Provisioning user...");
		}
	}
}
