namespace Bakery.Cqrs.Configuration
{
	using System;

	public class QueryCachingConfiguration
		: IQueryCachingConfiguration
	{
		public QueryCachingConfiguration()
			: this(null, null) { }

		public QueryCachingConfiguration(TimeSpan lifetime)
			: this(lifetime, null) { }

		public QueryCachingConfiguration(Priority? priority)
			: this(null, priority) { }

		public QueryCachingConfiguration(TimeSpan? lifetime, Priority? priority)
		{
			Lifetime = lifetime;
			Priority = priority;
		}

		public TimeSpan? Lifetime { get; private set; }
		public Priority? Priority { get; private set; }
	}
}
