namespace Bakery.Text
{
	using System;

	public interface IJsonParser
		: IParser<Object>
	{
		T TryParse<T>(String @string);
	}
}
