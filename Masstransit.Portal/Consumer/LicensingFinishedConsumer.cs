using System;
using System.Linq;
using System.Threading.Tasks;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Portal.Consumer
{
	public class LicensingFinishedConsumer : IConsumer<ILicensingFinished>
	{
		public async Task Consume(ConsumeContext<ILicensingFinished> context)
		{
			await Console.Out.WriteLineAsync("FINISHED:");
			await Console.Out.WriteLineAsync($"Customer: {context.Message.CustomerName}");
			await Console.Out.WriteLineAsync($"Username: {context.Message.UserName}");
			await Console.Out.WriteLineAsync($"Licenses: {context.Message.Licenses.Aggregate((currnet, next) => $"{currnet}, {next}")}");
		}
	}
}
