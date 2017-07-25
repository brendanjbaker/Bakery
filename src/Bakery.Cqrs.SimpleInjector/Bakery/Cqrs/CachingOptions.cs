namespace Bakery.Cqrs
{
	using SimpleInjector;
	using System;
	using System.Collections.Generic;
	using System.Reflection;

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

		public void AddQuery<TQuery>()
		{
			AddQuery(typeof(TQuery));
		}

		public void AddQuery(params Type[] queryTypes)
		{
			foreach (var queryType in queryTypes)
			{
				if (!IsQueryType(queryType))
					throw new InvalidOperationException($"{queryType.Name} does not implement {typeof(IQuery<>).Name}.");

				registrations.Add(new CachingRegistration(queryType));
			}
		}

		private static Boolean IsQueryType(Type type)
		{
			foreach (var @interface in type.GetTypeInfo().GetInterfaces())
				if (@interface.GetTypeInfo().IsGenericType)
					if (@interface.GetTypeInfo().GetGenericTypeDefinition() == typeof(IQuery<>))
						return true;

			return false;
		}
	}
}
