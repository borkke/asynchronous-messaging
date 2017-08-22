using System;
using System.Threading;
using System.Threading.Tasks;
using Masstransit.Service.Customer.Command;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Service.Customer.Consumer
{
	public class ProvisioningStartedConsumer : IConsumer<IProvisioningStarted>
	{
		public async Task Consume(ConsumeContext<IProvisioningStarted> context)
		{
			await Console.Out.WriteLineAsync($"Prvisioning started for {context.Message.CustomerName}");
			Thread.Sleep(TimeSpan.FromSeconds(3));
			await Console.Out.WriteLineAsync($"Prvisioning finished for {context.Message.CustomerName}");

			ICustomerCreated customerCreatedCommand = new CustomerCreatedCommand(context.Message.CustomerName, context.Message.UserName, context.Message.Licenses);
			var busControl = BusConfig.GetBus(QueueName.CustomerProvisioned, config => { });
			await busControl.Publish<ICustomerCreated>(customerCreatedCommand);
		}
	}
}
