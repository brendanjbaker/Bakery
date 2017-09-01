namespace Bakery.Security.Passwords
{
	using System;

	public static class PasswordGenerationExtensions
	{
		public static String GetCurrent(this IPasswordGenerationContext context)
		{
			String current = null;

			context.Transform(builder =>
			{
				current = builder.ToString();
			});

			if (current == null)
				throw new Exception("Password is null after transformation.");

			return current;
		}
	}
}
