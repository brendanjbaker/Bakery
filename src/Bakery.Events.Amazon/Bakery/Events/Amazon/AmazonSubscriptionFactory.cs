namespace Bakery.Events.Amazon
{
	using global::Amazon.SQS;
	using System;
	using Text;

	public class AmazonSubscriptionFactory
		: IAmazonSubscriptionFactory
	{
		private readonly Func<AmazonSQSClient> amazonSqsClientFactory;
		private readonly Func<IJsonParser> jsonParserFactory;

		public AmazonSubscriptionFactory(
			Func<AmazonSQSClient> amazonSqsClientFactory,
			Func<IJsonParser> jsonParserFactory)
		{
			this.amazonSqsClientFactory = amazonSqsClientFactory;
			this.jsonParserFactory = jsonParserFactory;
		}

		public ISubscription Create(String queueUrl)
		{
			var amazonSqsClient = amazonSqsClientFactory();
			var jsonParser = jsonParserFactory();

			return new AmazonSubscription(amazonSqsClient, jsonParser, queueUrl);
		}
	}
}
