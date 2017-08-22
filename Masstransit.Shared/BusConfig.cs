using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Masstransit.Shared
{
    public static class BusConfig
    {
		public static IBusControl GetBus(string queueName, Action<IRabbitMqBusFactoryConfigurator> moreInitialization)
		{
			return Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				var host = cfg.Host(new Uri("rabbitmq://localhost/vhost/"), queueName, h =>
				{
					h.Username("guest");
					h.Password("guest");
				});
				cfg.Durable = true;
				moreInitialization(cfg);
			});
		}
	}
}
