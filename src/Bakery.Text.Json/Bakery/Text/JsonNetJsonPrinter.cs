namespace Bakery.Text
{
	using Newtonsoft.Json;
	using System;

	public class JsonNetJsonPrinter
		: IJsonPrinter
	{
		private readonly JsonSerializerSettings jsonSerializerSettings;

		public JsonNetJsonPrinter() { }

		public JsonNetJsonPrinter(JsonSerializerSettings jsonSerializerSettings)
		{
			this.jsonSerializerSettings = jsonSerializerSettings ?? throw new ArgumentNullException(nameof(jsonSerializerSettings));
		}

		public String Print(Object @object)
		{
			return jsonSerializerSettings == null
				? JsonConvert.SerializeObject(@object)
				: JsonConvert.SerializeObject(@object, jsonSerializerSettings);
		}
	}
}
