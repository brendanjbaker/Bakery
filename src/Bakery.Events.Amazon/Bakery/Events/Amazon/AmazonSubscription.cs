namespace Bakery.Events.Amazon
{
	using global::Amazon.SQS;
	using global::Amazon.SQS.Model;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Text;

	public class AmazonSubscription
		: ISubscription
	{
		private readonly AmazonSQSClient amazonSqsClient;
		private readonly IJsonParser jsonParser;
		private readonly String queueUrl;

		public AmazonSubscription(AmazonSQSClient amazonSqsClient, IJsonParser jsonParser, String queueUrl)
		{
			this.amazonSqsClient = amazonSqsClient;
			this.jsonParser = jsonParser;
			this.queueUrl = queueUrl;
		}

		public void Dispose()
		{
			amazonSqsClient.DeleteQueueAsync(new DeleteQueueRequest(queueUrl)).Wait();
		}

		public async Task<IEnumerable<String>> ReceiveAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				var receiveResponse = await amazonSqsClient.ReceiveMessageAsync(new ReceiveMessageRequest()
				{
					MaxNumberOfMessages = 1,
					QueueUrl = queueUrl,
					WaitTimeSeconds = 20,
					VisibilityTimeout = 60
				}, cancellationToken);

				if (receiveResponse.Messages.Any())
				{
					var deleteRequestEntries = receiveResponse
						.Messages
						.Select(message => new DeleteMessageBatchRequestEntry()
						{
							Id = message.MessageId,
							ReceiptHandle = message.ReceiptHandle
						})
						.ToList();

					await amazonSqsClient.DeleteMessageBatchAsync(new DeleteMessageBatchRequest()
					{
						Entries = deleteRequestEntries,
						QueueUrl = queueUrl
					});

					return receiveResponse.Messages.Select(message =>
					{
						var amazonSqsMessage = jsonParser.Parse<AmazonSqsMessage>(message.Body);

						return amazonSqsMessage.Message;
					});
				}
			}

			return Enumerable.Empty<String>();
		}
	}
}
