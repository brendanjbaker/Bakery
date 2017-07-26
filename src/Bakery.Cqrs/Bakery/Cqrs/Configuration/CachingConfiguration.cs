namespace Bakery.Cqrs.Configuration
{
	using System;
	using System.Collections.Generic;

	public class CachingConfiguration
		: ICachingConfiguration
	{
		public CachingConfiguration(TimeSpan defaultLifetime, Priority defaultPriority, ReadDelegate read, WriteDelegate write, IDictionary<Type, IQueryCachingConfiguration> queryCachingConfigurations)
		{
			if (read == null)
				throw new ArgumentNullException(nameof(read));

			if (write == null)
				throw new ArgumentNullException(nameof(write));

			if (queryCachingConfigurations == null)
				throw new ArgumentNullException(nameof(queryCachingConfigurations));

			DefaultLifetime = defaultLifetime;
			DefaultPriority = defaultPriority;
			Read = read;
			Write = write;
			QueryCachingConfigurations = queryCachingConfigurations;
		}

		public TimeSpan DefaultLifetime { get; private set; }
		public Priority DefaultPriority { get; private set; }
		public IDictionary<Type, IQueryCachingConfiguration> QueryCachingConfigurations { get; private set; }
		public ReadDelegate Read { get; private set; }
		public WriteDelegate Write { get; private set; }
	}
}
