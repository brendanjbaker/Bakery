namespace Bakery.Security.Passwords
{
	using Bakery.Exceptions;
	using System;
	using System.Linq;
	using System.Text;

	public class PasswordGenerator
		: IPasswordGenerator
	{
		private readonly IRandom random;
		private readonly IPasswordGenerationRule[] rules;

		public PasswordGenerator(IRandom random, params IPasswordGenerationRule[] rules)
		{
			if (rules == null)
				throw new ArgumentNullException(nameof(rules));

			if (!rules.Any())
				throw new ArgumentEmptyException(nameof(rules));

			this.random = random ?? throw new ArgumentNullException(nameof(random));
			this.rules = rules;
		}

		public String Generate()
		{
			var context = new PasswordGenerationContext(random, new StringBuilder());

			foreach (var rule in rules)
				rule.Apply(context);

			return context.GetCurrent();
		}
	}
}
