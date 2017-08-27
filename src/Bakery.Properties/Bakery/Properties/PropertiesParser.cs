namespace Bakery.Properties
{
	using System;
	using Text;

	public class PropertiesParser
		: IPropertiesParser
	{
		private readonly ILineSplitter lineSplitter;

		public PropertiesParser(ILineSplitter lineSplitter)
		{
			if (lineSplitter == null)
				throw new ArgumentNullException(nameof(lineSplitter));

			this.lineSplitter = lineSplitter;
		}

		public IProperties Parse(String @string)
		{
			if (String.IsNullOrEmpty(@string))
				return null;

			var properties = new MemoryProperties();

			foreach (var line in lineSplitter.SplitLines(@string))
			{
				if (line.TrimStart().StartsWith("#"))
					continue;

				if (!line.Contains("="))
					continue;

				var parts = line.Split(new[] { '=' }, 2);
				var propertyName = parts[0].Trim();
				var propertyValue = parts[1].Trim();

				properties.Set(propertyName, propertyValue);
			}

			return properties;
		}
	}
}
