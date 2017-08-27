namespace Bakery.Exceptions
{
	using System;

	public class ArgumentEmptyException
		: ArgumentException
	{
		public ArgumentEmptyException(String argumentName)
			: base($@"Argument ""{argumentName}"" may not be empty.", argumentName) { }
	}
}
