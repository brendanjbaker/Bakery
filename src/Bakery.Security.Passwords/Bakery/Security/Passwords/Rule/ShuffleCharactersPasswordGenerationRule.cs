namespace Bakery.Security.Passwords.Rule
{
	using Bakery.Exceptions;
	using System;

	public class ShuffleCharactersPasswordGenerationRule
		: IPasswordGenerationRule
	{
		private readonly Int32 iterations;

		public ShuffleCharactersPasswordGenerationRule(Int32 iterations)
		{
			if (iterations <= 0)
				throw new ArgumentNotPositiveException(nameof(iterations));

			this.iterations = iterations;
		}

		public void Apply(IPasswordGenerationContext context)
		{
			context.Transform(builder =>
			{
				for (var i = 0; i < iterations; i++)
				{
					var index1 = context.Random.GetInt32() % builder.Length;
					var index2 = context.Random.GetInt32() % builder.Length;

					var character1 = builder[index1];
					var character2 = builder[index2];

					builder[index1] = character2;
					builder[index2] = character1;
				}
			});
		}
	}
}
