namespace Bakery.Configuration.Properties
{
	using Caching;
	using System;
	using System.Collections.Generic;

	public class CachingProperties
		: IProperties
	{
		private readonly ICache<IProperties> cache;
		private readonly IProperties source;

		public CachingProperties(
			ICache<IProperties> cache,
			IProperties source)
		{
			if (cache == null)
				throw new ArgumentNullException(nameof(cache));

			if (source == null)
				throw new ArgumentNullException(nameof(source));

			this.cache = cache;
			this.source = source;
		}

		public IDictionary<String, String> ToDictionary()
		{
			var properties = cache.TryRead();

			if (properties != null)
				return properties.ToDictionary();

			properties = new MemoryProperties(source.ToDictionary());

			cache.Write(properties);

			return properties.ToDictionary();
		}
	}
}
