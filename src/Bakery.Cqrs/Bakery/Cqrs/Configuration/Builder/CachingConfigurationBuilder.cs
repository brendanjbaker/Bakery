namespace Bakery.Cqrs.Configuration.Builder
{
	using Exception;
	using System;
	using System.Collections.Generic;

	public class CachingConfigurationBuilder
		: ICachingConfigurationBuilder
	{
		private readonly IDictionary<Type, IQueryCachingConfiguration> queryCachingConfigurations;

		private TimeSpan? defaultLifetime;
		private Priority? defaultPriority;
		private ReadDelegate read;
		private WriteDelegate write;

		public CachingConfigurationBuilder()
		{
			queryCachingConfigurations = new Dictionary<Type, IQueryCachingConfiguration>();
		}

		public ICachingConfigurationBuilder Cache<TQuery>()
		{
			return Cache(typeof(TQuery));
		}

		public ICachingConfigurationBuilder Cache<TQuery>(Priority priority)
		{
			return Cache(typeof(TQuery), priority: priority);
		}

		public ICachingConfigurationBuilder Cache<TQuery>(TimeSpan lifetime)
		{
			return Cache(typeof(TQuery), lifetime);
		}

		public ICachingConfigurationBuilder Cache<TQuery>(TimeSpan lifetime, Priority priority)
		{
			return Cache(typeof(TQuery), lifetime, priority);
		}

		public ICachingConfigurationBuilder SetAdapter(ReadDelegate read, WriteDelegate write)
		{
			if (read == null)
				throw new ArgumentNullException(nameof(read));

			if (write == null)
				throw new ArgumentNullException(nameof(write));

			if (this.read != null || this.write != null)
				throw new DuplicateBuilderOptionException();

			this.read = read;
			this.write = write;

			return this;
		}

		public ICachingConfigurationBuilder SetDefaultLifetime(TimeSpan lifetime)
		{
			return Builder.SetOption(this, ref defaultLifetime, () => lifetime);
		}

		public ICachingConfigurationBuilder SetDefaultPriority(Priority priority)
		{
			return Builder.SetOption(this, ref defaultPriority, () => priority);
		}

		public ICachingConfiguration Build()
		{
			if (read == null)
				throw new InvalidOperationException("Reading delegate is required.");

			if (write == null)
				throw new InvalidOperationException("Writing delegate is required.");

			return new CachingConfiguration(
				defaultLifetime: defaultLifetime ?? TimeSpan.FromMinutes(1),
				defaultPriority: defaultPriority ?? Priority.Normal,
				read: read,
				write: write,
				queryCachingConfigurations: queryCachingConfigurations);
		}

		private ICachingConfigurationBuilder Cache(Type queryType, TimeSpan? lifetime = null, Priority? priority = null)
		{
			if (queryCachingConfigurations.ContainsKey(queryType))
				throw new DuplicateBuilderOptionException();

			queryCachingConfigurations[queryType] = new QueryCachingConfiguration(lifetime, priority);

			return this;
		}
	}
}
