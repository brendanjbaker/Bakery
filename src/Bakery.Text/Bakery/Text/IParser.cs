namespace Bakery.Text
{
	using System;

	public interface IParser<T>
	{
		T Parse(String @string);
	}
}
