namespace Bakery.Events.Amazon
{
	using System;

	public class AmazonSqsMessage
	{
		public String Type { get; set; }
		public Guid MessageId { get; set; }
		public String TopicArn { get; set; }
		public String Message { get; set; }
		public DateTime Timestamp { get; set; }
		public String SignatureVersion { get; set; }
		public String Signature { get; set; }
		public String SigningCertURL { get; set; }
		public String UnsubscribeURL { get; set; }
	}
}
