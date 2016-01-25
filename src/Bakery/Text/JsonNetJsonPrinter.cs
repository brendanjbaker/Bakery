namespace Bakery.Text
{
	using Newtonsoft.Json;
	using System;

	public class JsonNetJsonPrinter
		: IJsonPrinter
	{
		public String Print(Object @object)
		{
			return JsonConvert.SerializeObject(@object);
		}
	}
}
