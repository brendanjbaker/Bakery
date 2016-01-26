namespace Bakery.Text
{
	using Newtonsoft.Json;
	using System;

	public class JsonNetJsonParser
		: IJsonParser
	{
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
