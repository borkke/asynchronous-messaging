using System;
using System.Collections.Generic;
using Masstransit.Portal.Command;
using Masstransit.Portal.Consumer;
using Masstransit.Shared;
using MassTransit;

namespace Masstransit.Portal
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Portal");

			var busControl = BusConfig.GetBus(QueueName.CustomerSubmitted, config =>
			{
				config.ReceiveEndpoint(QueueName.LicensesAssigned, endpoint =>
				{
					endpoint.Consumer<ProvisioningStartedConsumer>();
					endpoint.Consumer<CustomerCreatedConsumer>();
					endpoint.Consumer<UserCreatedConsumer>();
					endpoint.Consumer<LicensingFinishedConsumer>();
				});
			});
			busControl.Start();

			var customerName = "";
			while (customerName != "quit")
			{
				if (customerName == "quit") break;

				var provisioningStartedMessage = GetProvisioningStartedMessage(customerName);
				busControl.Publish(provisioningStartedMessage);
			}

			busControl.Stop();
		}

		private static IProvisioningStarted GetProvisioningStartedMessage(string customerName)
		{
			Console.Write("Enter a customer id: ");
			customerName = Console.ReadLine();

			Console.Write("Enter a username id: ");
			var username = Console.ReadLine();

			var licenses = new List<string> { "E1", "O365" };

			return new ProvisioningStartedCommand(customerName, username, licenses);
		}
	}
}
