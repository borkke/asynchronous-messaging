using System;
using Masstransit.Service.User.Consumer;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Service.User
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("User");

			var busControl = BusConfig.GetBus(QueueName.UserCreated, config =>
			{
				config.ReceiveEndpoint(QueueName.CustomerProvisioned, endpoint =>
				{
					endpoint.Consumer<CustomerCreatedConsumer>();
				});
			});

			busControl.Start();

			Console.ReadKey();

			busControl.Stop();
		}
	}
}
