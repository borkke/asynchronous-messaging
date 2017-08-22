using System;
using Masstransit.Service.Licensing.Consumer;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Service.Licensing
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Licensing");

			var busControl = BusConfig.GetBus(QueueName.LicensesAssigned, config =>
			{
				config.ReceiveEndpoint(QueueName.UserCreated, endpoint =>
				{
					endpoint.Consumer<UserCreatedConsumer>();
				});
			});

			busControl.Start();

			Console.ReadKey();

			busControl.Stop();
		}
	}
}
