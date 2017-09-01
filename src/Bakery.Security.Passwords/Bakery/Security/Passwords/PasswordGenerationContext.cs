namespace Bakery.Security.Passwords
{
	using System;
	using System.Text;

	public class PasswordGenerationContext
		: IPasswordGenerationContext
	{
		private readonly IRandom random;
		private readonly StringBuilder stringBuilder;

		public PasswordGenerationContext(IRandom random, StringBuilder stringBuilder)
		{
			this.random = random ?? throw new ArgumentNullException(nameof(random));
			this.stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
		}

		public IRandom Random => random;

		public void Transform(Action<StringBuilder> transform)
		{
			transform(stringBuilder);
		}
	}
}
