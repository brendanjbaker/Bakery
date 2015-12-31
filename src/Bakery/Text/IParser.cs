namespace Bakery.Text
{
	using System;

	public interface IParser<T>
	{
		T TryParse(String @string);
	}
}
