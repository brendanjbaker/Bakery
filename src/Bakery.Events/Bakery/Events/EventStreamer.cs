namespace Bakery.Events
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class EventStreamer
		: IEventStreamer
	{
		private readonly IEventSubscriber eventSubscriber;

		public EventStreamer(IEventSubscriber eventSubscriber)
		{
			this.eventSubscriber = eventSubscriber;
		}

		public async Task StreamAsync(String topic, CancellationToken cancellationToken, Func<String, Task> receiveFunction)
		{
			using (var subscription = await eventSubscriber.SubscribeAsync(topic))
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					var messages = await subscription.ReceiveAsync(cancellationToken);

					foreach (var message in messages)
					{
						await receiveFunction(message);
					}
				}
			}
		}
	}
}
