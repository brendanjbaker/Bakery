using Bakery.Cqrs;
using SimpleInjector;
using SimpleInjector.Advanced;
using System;

public static class ContainerExtensions
{
	public static void RegisterCqrs(this Container container)
	{
		container.RegisterCqrs(options => { });
	}

	public static void RegisterCqrs(this Container container, Action<RegistrationOptions> options)
	{
		if (options == null)
			throw new ArgumentNullException(nameof(options));

		container.RegisterSingleton<IDispatcher, Dispatcher>();
		container.RegisterSingleton<ICommandDispatcher, SimpleInjectorCommandDispatcher>();
		container.RegisterSingleton<IQueryDispatcher, SimpleInjectorQueryDispatcher>();

		options(new RegistrationOptions(container));
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

	private static void RegisterHandler(Container container, Type serviceType, Type handlerType)
	{
		var registration =
			Lifestyle.Singleton.CreateRegistration(
				serviceType: handlerType,
				instanceCreator: () => container.GetInstance(handlerType),
				container: container);

		container.AppendToCollection(serviceType, registration);
	}
}
