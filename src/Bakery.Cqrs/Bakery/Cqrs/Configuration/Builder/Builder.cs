namespace Bakery.Cqrs.Configuration.Builder
{
	using Exception;
	using System;

	internal static class Builder
	{
		public static TBuilder SetOption<TBuilder, TValue>(TBuilder builder, ref TValue field, Func<TValue> valueFunction)
		{
			if (field != null)
				throw new DuplicateBuilderOptionException();

			field = valueFunction();

			return builder;
		}
	}
}
