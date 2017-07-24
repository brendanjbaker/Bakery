namespace Bakery.Cqrs
{
	using SimpleInjector;
	using SimpleInjector.Advanced;
	using System;
	using System.Reflection;

	public class RegistrationOptions
	{
		private readonly Container container;

		internal RegistrationOptions(Container container)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			this.container = container;
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
