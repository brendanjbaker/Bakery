namespace Bakery.Configuration.Properties
{
	using System;
	using System.Collections.Generic;

	public class CascadingProperties
		: IProperties
	{
		private readonly IProperties[] properties;

		public CascadingProperties(params IProperties[] properties)
		{
			if (properties == null)
				throw new ArgumentNullException(nameof(properties));

			this.properties = properties;
		}

		public IDictionary<String, String> ToDictionary()
		{
			var cascadedProperties = new MemoryProperties();

			for (var i = properties.Length - 1; i >= 0; i--)
			{
				Patch(cascadedProperties, properties[i]);
			}

			return cascadedProperties.ToDictionary();
		}

		private static void Patch(MemoryProperties baseProperties, IProperties deltaProperties)
		{
			foreach (var property in deltaProperties.ToDictionary())
			{
				baseProperties.Set(property.Key, property.Value);
			}
		}
	}
}
