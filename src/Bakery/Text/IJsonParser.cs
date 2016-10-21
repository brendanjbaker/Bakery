namespace Bakery.Text
{
	using System;

	public interface IJsonParser
		: IParser<Object>
	{
		T Parse<T>(String @string);
		T TryParse<T>(String @string);
	}
}
