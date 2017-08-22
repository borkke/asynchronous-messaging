using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Masstransit.Service.Licensing.Command;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Service.Licensing.Consumer
{
	public class UserCreatedConsumer : IConsumer<IUserCreated>
	{
		public async Task Consume(ConsumeContext<IUserCreated> context)
		{
			await Console.Out.WriteLineAsync($"Starting assigning licenses: \n {context.Message.Licenses.Aggregate((currnet, next) => $"{currnet}, {next}")}");
			Thread.Sleep(TimeSpan.FromSeconds(2));
			await Console.Out.WriteLineAsync($"Finished assigning licenses: \n {context.Message.CustomerName}");

			ILicensingFinished userCreatedCommand = new LicensingFinishedCommand(context.Message.CustomerName, context.Message.UserName, context.Message.Licenses);
			var busControl = BusConfig.GetBus(QueueName.LicensesAssigned, config => { });
			await busControl.Publish<ILicensingFinished>(userCreatedCommand);
		}
	}
}
