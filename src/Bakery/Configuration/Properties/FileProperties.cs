namespace Bakery.Configuration.Properties
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	public class FileProperties
		: IProperties
	{
		private readonly IPropertiesParser propertiesParser;
		private readonly String path;

		public FileProperties(IPropertiesParser propertiesParser, String path)
		{
			if (propertiesParser == null)
				throw new ArgumentNullException(nameof(propertiesParser));

			if (path == null)
				throw new ArgumentNullException(nameof(path));

			this.propertiesParser = propertiesParser;
			this.path = path;
		}

		public IDictionary<String, String> ToDictionary()
		{
			if (!File.Exists(path))
				return new EmptyProperties().ToDictionary();

			var properties = propertiesParser.TryParse(File.ReadAllText(path));

			if (properties == null)
				return new EmptyProperties().ToDictionary();

			return properties.ToDictionary();
		}
	}
}
