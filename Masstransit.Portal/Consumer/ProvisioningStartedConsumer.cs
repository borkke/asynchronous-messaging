using System;
using System.Threading.Tasks;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Portal.Consumer
{
	public class ProvisioningStartedConsumer : IConsumer<IProvisioningStarted>
	{
		public async Task Consume(ConsumeContext<IProvisioningStarted> context)
		{
			await Console.Out.WriteLineAsync("\n \n \n Provisioning customer...");
		}
	}
}
