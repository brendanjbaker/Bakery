namespace Bakery.Security.Passwords.Rule
{
	using Bakery.Exceptions;
	using System;

	public class AddCharactersPasswordGenerationRule
		: IPasswordGenerationRule
	{
		private readonly Int32 count;
		private readonly IAlphabet alphabet;

		public AddCharactersPasswordGenerationRule(Int32 count, IAlphabet alphabet)
		{
			if (count <= 0)
				throw new ArgumentNotPositiveException(nameof(count));

			this.count = count;
			this.alphabet = alphabet ?? throw new ArgumentNullException(nameof(alphabet));
		}

		public void Apply(IPasswordGenerationContext context)
		{
			context.Transform(builder =>
			{
				for (var i = 0; i < count; i++)
				{
					builder.Append(alphabet.Random(context.Random));
				}
			});
		}
	}
}
