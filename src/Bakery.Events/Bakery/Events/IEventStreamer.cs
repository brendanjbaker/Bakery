namespace Bakery.Events
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IEventStreamer
	{
		Task StreamAsync(String topic, CancellationToken cancellationToken, Func<String, Task> receiveFunction);
	}
}
