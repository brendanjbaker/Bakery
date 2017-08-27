namespace Bakery.Exceptions
{
	using System;

	public class ArgumentWhitespaceException
		: ArgumentException
	{
		public ArgumentWhitespaceException(String argumentName, String argumentValue)
			: base($@"Argument ""{argumentName}"" contains inappropriate whitespace: ""{argumentValue}"".", argumentName) { }
	}
}
