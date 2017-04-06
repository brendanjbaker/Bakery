namespace Bakery.Exceptions
{
	using System;

	public class ArgumentNegativeException
		: ArgumentOutOfRangeException
	{
		public ArgumentNegativeException(String argumentName)
			: base(argumentName, "May not be negative.") { }
	}
}
