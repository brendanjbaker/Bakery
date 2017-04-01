namespace Bakery.Events.Amazon
{
	using System;

	public interface IAmazonSubscriptionFactory
	{
		ISubscription Create(String queueUrl);
	}
}
