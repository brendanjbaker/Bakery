namespace Bakery.Text
{
	using Newtonsoft.Json;
	using System;

	public class JsonNetJsonParser
		: IJsonParser
	{
		private readonly JsonSerializerSettings jsonSerializerSettings;

		public JsonNetJsonParser() { }

		public JsonNetJsonParser(JsonSerializerSettings jsonSerializerSettings)
		{
			this.jsonSerializerSettings = jsonSerializerSettings ?? throw new ArgumentNullException(nameof(jsonSerializerSettings));
		}

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
			return jsonSerializerSettings == null
				? JsonConvert.DeserializeObject<T>(@string)
				: JsonConvert.DeserializeObject<T>(@string, jsonSerializerSettings);
		}
	}
}
