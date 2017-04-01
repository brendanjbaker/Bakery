namespace Bakery.Events.Amazon
{
	using global::Amazon.Auth.AccessControlPolicy;
	using global::Amazon.Auth.AccessControlPolicy.ActionIdentifiers;
	using global::Amazon.SimpleNotificationService;
	using global::Amazon.SimpleNotificationService.Model;
	using global::Amazon.SQS;
	using global::Amazon.SQS.Model;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class AmazonEventSubscriber
		: IEventSubscriber
	{
		private readonly AmazonSimpleNotificationServiceClient amazonSnsClient;
		private readonly AmazonSQSClient amazonSqsClient;
		private readonly IAmazonSubscriptionFactory amazonSubscriptionFactory;

		public AmazonEventSubscriber(
			AmazonSimpleNotificationServiceClient amazonSnsClient,
			AmazonSQSClient amazonSqsClient,
			IAmazonSubscriptionFactory amazonSubscriptionFactory)
		{
			this.amazonSnsClient = amazonSnsClient;
			this.amazonSqsClient = amazonSqsClient;
			this.amazonSubscriptionFactory = amazonSubscriptionFactory;
		}

		public async Task<ISubscription> SubscribeAsync(String topic)
		{
			var amazonTopic = await amazonSnsClient.CreateTopicAsync(new CreateTopicRequest()
			{
				Name = topic
			});

			var queue = await amazonSqsClient.CreateQueueAsync(new CreateQueueRequest()
			{
				QueueName = Guid.NewGuid().ToString()
			});

			var queueAttributes = await amazonSqsClient.GetQueueAttributesAsync(new GetQueueAttributesRequest()
			{
				AttributeNames = new List<String>(new String[] { "QueueArn" }),
				QueueUrl = queue.QueueUrl
			});

			var policy = new Policy()
				.WithStatements(
					new Statement(Statement.StatementEffect.Allow)
						.WithPrincipals(Principal.AllUsers)
						.WithConditions(ConditionFactory.NewSourceArnCondition(amazonTopic.TopicArn))
						.WithResources(new Resource(queueAttributes.QueueARN))
						.WithActionIdentifiers(SQSActionIdentifiers.SendMessage));

			await amazonSqsClient.SetQueueAttributesAsync(queue.QueueUrl, new Dictionary<String, String>()
			{
				["Policy"] = policy.ToJson()
			});

			await amazonSnsClient.SubscribeAsync(new SubscribeRequest()
			{
				Endpoint = queueAttributes.QueueARN,
				Protocol = "sqs",
				TopicArn = amazonTopic.TopicArn
			});

			var subscription = amazonSubscriptionFactory.Create(queue.QueueUrl);

			return subscription;
		}
	}
}
