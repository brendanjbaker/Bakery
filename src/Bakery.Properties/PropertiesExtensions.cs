namespace Bakery.Properties
{
	using System;

	public static class PropertiesExtensions
	{
		public static Boolean GetBoolean(this IProperties properties, String propertyName)
		{
			return Boolean.Parse(properties.GetString(propertyName));
		}

		public static Int32 GetInteger(this IProperties properties, String propertyName)
		{
			return Int32.Parse(properties.GetString(propertyName));
		}

		public static String GetString(this IProperties properties, String propertyName)
		{
			String value;

			var propertyDictionary = properties.ToDictionary();

			if (!propertyDictionary.TryGetValue(propertyName, out value))
				throw new PropertyNotFoundException(propertyName);

			return value;
		}
	}
}
