namespace Bakery.Cqrs
{
	using Caching;
	using SimpleInjector;
	using SimpleInjector.Advanced;
	using System;
	using System.Reflection;
	using Time;

	public class RegistrationOptions
	{
		private readonly Container container;

		internal RegistrationOptions(Container container)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			this.container = container;
		}

		public void EnableCaching(Action<CachingOptions> options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			var cachingOptions = new CachingOptions(container);

			options(cachingOptions);

			var cachingConfiguration = new CachingConfiguration(cachingOptions.Registrations);

			container.RegisterSingleton<ICachingConfiguration>(cachingConfiguration);
			container.RegisterSingleton<IQueryCache>(new QueryCache(new KeyedCache<Object, Object>(() => new DurationCache<Object>(new SystemClock(), TimeSpan.FromDays(365 * 100))), cachingConfiguration));
			container.RegisterDecorator<IQueryDispatcher, CachingQueryDispatcher>(Lifestyle.Singleton);
		}

		public void ScanAssembly(Assembly assembly)
		{
			if (assembly == null)
				throw new ArgumentNullException(nameof(assembly));

			RegisterAllTypes(typeof(ICommandHandler<>), assembly);
			RegisterAllTypes(typeof(IQueryHandler<,>), assembly);
		}

		private void RegisterAllTypes(Type serviceType, Assembly assembly)
		{
			var implementationTypes = container.GetTypesToRegister(serviceType, new[] { assembly });

			foreach (var implementationType in implementationTypes)
			{
				container.RegisterSingleton(implementationType, implementationType);
				container.AppendToCollection(serviceType, Lifestyle.Singleton.CreateRegistration(implementationType, () => container.GetInstance(implementationType), container));
			}
		}
	}
}
