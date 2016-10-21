namespace Bakery.Text
{
	using System;

	public class ParseException<T>
		: Exception
	{
		public override String Message
		{
			get { return $"Failed to parse type {typeof(T).Name}."; }
		}
	}
}
