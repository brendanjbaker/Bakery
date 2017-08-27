namespace Bakery.Dns.Tokenization
{
	using System;

	public class MultipleCharacterTokenizer
		: ITokenScanner
	{
		private readonly ITokenScanner[] characterTokenizers;

		public MultipleCharacterTokenizer(params ITokenScanner[] characterTokenizers)
		{
			this.characterTokenizers = characterTokenizers ?? throw new ArgumentNullException(nameof(characterTokenizers));
		}

		public void TryScanNextToken(TokenizationContext context)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			foreach (var characterTokenizer in characterTokenizers)
			{
				var position = context.Position;

				characterTokenizer.TryScanNextToken(context);

				// If the position has advanced, then a token should have been registered.
				// To-do: throw exception if the position advanced, but no token was registered.

				if (context.Position > position)
					return;
			}

			throw new TokenizationException(context);
		}
	}
}
