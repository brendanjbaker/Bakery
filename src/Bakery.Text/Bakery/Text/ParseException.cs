namespace Bakery.Text
{
	using System;

	public class ParseException<T>
		: Exception
	{
		public override String Message => $"Failed to parse type {typeof(T).Name}.";
	}
}
