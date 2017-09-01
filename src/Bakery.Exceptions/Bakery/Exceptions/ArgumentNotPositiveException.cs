namespace Bakery.Exceptions
{
	using System;

	public class ArgumentNotPositiveException
		: ArgumentOutOfRangeException
	{
		public ArgumentNotPositiveException(String argumentName)
			: base(argumentName, "Must be positive.") { }
	}
}
