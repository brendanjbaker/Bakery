namespace Bakery.Events
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;

	public interface ISubscription
		: IDisposable
	{
		Task<IEnumerable<String>> ReceiveAsync(CancellationToken cancellationToken);
	}
}
