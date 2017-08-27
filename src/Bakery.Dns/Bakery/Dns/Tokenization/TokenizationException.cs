namespace Bakery.Dns.Tokenization
{
	using System;

	public class TokenizationException
		: Exception
	{
		private readonly TokenizationContext context;

		public TokenizationException(TokenizationContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public override String Message
		{
			get
			{
				var substring = context.Next.ToString();

				if (context.Characters.Length > context.Position + 20)
					substring = context.Characters.Substring(context.Position, 20);

				var message = $@"Invalid character at position #{context.Position}: ""{substring}"".";

				return message;
			}
		}
	}
}
