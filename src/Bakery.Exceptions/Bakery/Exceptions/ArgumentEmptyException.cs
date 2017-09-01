namespace Bakery.Exceptions
{
	using System;

	public class ArgumentEmptyException
		: ArgumentException
	{
		public ArgumentEmptyException(String argumentName)
			: base("May not be empty.", argumentName) { }
	}
}
