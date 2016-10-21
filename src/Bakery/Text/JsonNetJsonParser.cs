namespace Bakery.Text
{
	using Newtonsoft.Json;
	using System;

	public class JsonNetJsonParser
		: IJsonParser
	{
		public T Parse<T>(String @string)
		{
			var @object = TryParse<T>(@string);

			if (@object == null)
				throw new ParseException<T>();

			return @object;
		}

		public Object TryParse(String @string)
		{
			return TryParse<Object>(@string);
		}

		public T TryParse<T>(String @string)
		{
			return JsonConvert.DeserializeObject<T>(@string);
		}
	}
}
