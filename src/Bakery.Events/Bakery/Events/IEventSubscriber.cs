namespace Bakery.Events
{
	using System;
	using System.Threading.Tasks;

	public interface IEventSubscriber
	{
		Task<ISubscription> SubscribeAsync(String topic);
	}
}
