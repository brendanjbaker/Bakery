namespace Bakery.Events.Amazon
{
	using global::Amazon.SimpleNotificationService;
	using global::Amazon.SimpleNotificationService.Model;
	using System;
	using System.Threading.Tasks;
	using Text;

	public class AmazonEventPublisher
		: IEventPublisher
	{
		private readonly AmazonSimpleNotificationServiceClient amazonSnsClient;
		private readonly IJsonPrinter jsonPrinter;

		public AmazonEventPublisher(
			AmazonSimpleNotificationServiceClient amazonSnsClient,
			IJsonPrinter jsonPrinter)
		{
			this.amazonSnsClient = amazonSnsClient;
			this.jsonPrinter = jsonPrinter;
		}

		public async Task PublishAsync(String topic, IEvent @event)
		{
			var topicArn = await GetTopicArn(topic);
			var message = jsonPrinter.Print(@event);

			await amazonSnsClient.PublishAsync(new PublishRequest()
			{
				Message = message,
				TopicArn = topicArn
			});
		}

		private async Task<String> GetTopicArn(String topic)
		{
			var amazonTopic = await amazonSnsClient.FindTopicAsync(topic);

			if (amazonTopic != null)
				return amazonTopic.TopicArn;

			var createTopicResponse = await amazonSnsClient.CreateTopicAsync(new CreateTopicRequest()
			{
				Name = topic
			});

			return createTopicResponse.TopicArn;
		}
	}
}
