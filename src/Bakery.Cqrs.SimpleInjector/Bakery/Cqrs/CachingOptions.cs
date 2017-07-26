namespace Bakery.Cqrs
{
	using Caching;
	using SimpleInjector;
	using System;
	using System.Collections.Generic;
	using Time;

	public class CachingOptions
	{
		private readonly Container container;
		private readonly ICollection<ICachingRegistration> registrations;

		internal CachingOptions(Container container)
			: this(container, new List<ICachingRegistration>()) { }

		internal CachingOptions(Container container, ICollection<ICachingRegistration> registrations)
		{
			this.container = container;
			this.registrations = registrations;
		}

		internal IEnumerable<ICachingRegistration> Registrations => registrations;

		public void AddQuery<TQuery>() => AddQuery(typeof(TQuery));

		public void AddQuery<TQuery>(TimeSpan duration) => AddQuery(typeof(TQuery), duration);

		public void AddQuery(Type queryType)
		{
			AssertIsQueryType(queryType);

			registrations.Add(new CachingRegistration(queryType, () => new InfiniteCache<Object>()));
		}

		public void AddQuery(Type queryType, TimeSpan duration)
		{
			AssertIsQueryType(queryType);

			registrations.Add(new CachingRegistration(queryType, () => new DurationCache<Object>(container.GetInstance<IClock>(), duration)));
		}

		private static void AssertIsQueryType(Type type)
		{
			if (!type.IsQuery())
				throw new InvalidOperationException($"{type.Name} does not implement {typeof(IQuery<>).Name}.");
		}
	}
}
