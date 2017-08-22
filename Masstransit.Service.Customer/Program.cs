using System;
using Masstransit.Service.Customer.Consumer;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Service.Customer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Customer");

			var busControl = BusConfig.GetBus(QueueName.CustomerProvisioned, config =>
			{
				config.ReceiveEndpoint(QueueName.CustomerSubmitted, endpoint =>
				{
					endpoint.Consumer<ProvisioningStartedConsumer>();
				});
			});
			busControl.Start();

			Console.ReadKey();

			busControl.Stop();
		}
	}
}
