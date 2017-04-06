namespace Bakery.Exceptions
{
	using System;

	public class ArgumentGreaterThanOtherArgumentException
		: ArgumentOutOfRangeException
	{
		public ArgumentGreaterThanOtherArgumentException(String argumentName, String otherArgumentName)
			: base(argumentName, $@"May not be greater than argument ""{otherArgumentName}"".") { }
	}
}
