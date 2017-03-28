namespace Bakery.Configuration.Properties
{
	using System;
	using System.Collections.Generic;

	public class MemoryProperties
		: IProperties
	{
		private readonly IDictionary<String, String> properties;

		public MemoryProperties()
			: this(new Dictionary<String, String>())
		{ }

		public MemoryProperties(IDictionary<String, String> properties)
		{
			if (properties == null)
				throw new ArgumentNullException(nameof(properties));

			this.properties = properties;
		}

		public void Set(String propertyName, String propertyValue)
		{
			if (propertyName == null)
				throw new ArgumentNullException(nameof(propertyName));

			properties[propertyName] = propertyValue;
		}

		public IDictionary<String, String> ToDictionary()
		{
			return new Dictionary<String, String>(properties);
		}
	}
}
