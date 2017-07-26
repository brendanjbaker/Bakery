using Bakery.Cqrs;
using Bakery.Cqrs.Configuration;
using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Reflection;

public static class ContainerExtensions
{
	public static void RegisterCqrs(this Container container, IConfiguration configuration)
	{
		if (configuration == null)
			throw new ArgumentNullException(nameof(configuration));

		container.RegisterSingleton<IDispatcher, Dispatcher>();
		container.RegisterSingleton<ICommandDispatcher, SimpleInjectorCommandDispatcher>();
		container.RegisterSingleton<IQueryDispatcher, SimpleInjectorQueryDispatcher>();

		container.RegisterSingleton(configuration);

		if (configuration.CachingConfiguration != null)
		{
			container.RegisterDecorator<IQueryDispatcher, CachingQueryDispatcher>(Lifestyle.Singleton);
			container.RegisterSingleton(configuration.CachingConfiguration);
		}
	}

	public static void RegisterCommandHandler<TCommandHandler>(this Container container)
		where TCommandHandler : ICommandHandler
	{
		container.RegisterCommandHandler(typeof(TCommandHandler));
	}

	public static void RegisterCommandHandler(this Container container, Type commandHandlerType)
	{
		commandHandlerType.AssertImplementsInterface(typeof(ICommandHandler<>));

		RegisterHandler(container, typeof(ICommandHandler<>), commandHandlerType);
	}

	public static void RegisterCommandHandlers(this Container container, Assembly assembly)
	{
		RegisterHandlers(container, typeof(ICommandHandler<>), assembly);
	}

	public static void RegisterHandlers(this Container container, Assembly assembly)
	{
		container.RegisterCommandHandlers(assembly);
		container.RegisterQueryHandlers(assembly);
	}

	public static void RegisterQueryHandler<TQueryHandler>(this Container container)
		where TQueryHandler : IQueryHandler
	{
		container.RegisterQueryHandler(typeof(TQueryHandler));
	}

	public static void RegisterQueryHandler(this Container container, Type queryHandlerType)
	{
		queryHandlerType.AssertImplementsInterface(typeof(IQueryHandler<,>));

		RegisterHandler(container, typeof(IQueryHandler<,>), queryHandlerType);
	}

	public static void RegisterQueryHandlers(this Container container, Assembly assembly)
	{
		RegisterHandlers(container, typeof(IQueryHandler<,>), assembly);
	}

	private static void RegisterHandler(Container container, Type serviceType, Type handlerType)
	{
		var registration =
			Lifestyle.Singleton.CreateRegistration(
				serviceType: handlerType,
				instanceCreator: () => container.GetInstance(handlerType),
				container: container);

		container.AppendToCollection(serviceType, registration);
	}

	private static void RegisterHandlers(Container container, Type serviceType, Assembly assembly)
	{
		var handlerTypes = container.GetTypesToRegister(serviceType, new[] { assembly });

		foreach (var handlerType in handlerTypes)
			RegisterHandler(container, serviceType, handlerType);
	}
}
