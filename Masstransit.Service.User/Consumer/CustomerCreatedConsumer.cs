using System;
using System.Threading;
using System.Threading.Tasks;
using Masstransit.Service.User.Command;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Service.User.Consumer
{
	public class CustomerCreatedConsumer : IConsumer<ICustomerCreated>
	{
		public async Task Consume(ConsumeContext<ICustomerCreated> context)
		{
			await Console.Out.WriteLineAsync($"Provisioing user started for {context.Message.UserName}");
			Thread.Sleep(TimeSpan.FromSeconds(3));
			await Console.Out.WriteLineAsync($"Prvisioning user for {context.Message.UserName}");

			IUserCreated userCreatedCommand = new UserCreatedCommand(context.Message.CustomerName, context.Message.UserName, context.Message.Licenses);
			var busControl = BusConfig.GetBus(QueueName.UserCreated, config => { });
			await busControl.Publish<IUserCreated>(userCreatedCommand);
		}
	}
}
