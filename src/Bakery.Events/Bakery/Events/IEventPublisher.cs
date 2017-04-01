namespace Bakery.Events
{
	using System;
	using System.Threading.Tasks;

	public interface IEventPublisher
	{
		Task PublishAsync(String topic, IEvent @event);
	}
}
