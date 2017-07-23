using Bakery.Cqrs;
using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Reflection;

public static class ContainerExtensions
{
	public static void RegisterCommand<TCommand, TCommandHandler>(this Container container)
		where TCommand : ICommand
		where TCommandHandler : class, ICommandHandler<TCommand>
	{
		var registration = Bakery.Cqrs.Registration.Create(() => container.GetInstance<ICommandHandler<TCommand>>());

		container.RegisterSingleton<TCommandHandler>();
		container.AppendToCollection(typeof(IRegistration), Lifestyle.Singleton.CreateRegistration(() => registration, container));
	}

	public static void RegisterCommandHandler<TCommandHandler>(this Container container)
		where TCommandHandler : class
	{
		foreach (var @interface in typeof(TCommandHandler).GetTypeInfo().GetInterfaces())
		{
			if (!IsCommandHandlerInterface(@interface))
				continue;

			var commandType = @interface.GetTypeInfo().GenericTypeArguments[0];
			var registration = Bakery.Cqrs.Registration.Create(commandType, () => container.GetInstance<TCommandHandler>());

			container.RegisterSingleton(typeof(TCommandHandler), typeof(TCommandHandler));
			container.AppendToCollection(typeof(IRegistration), Lifestyle.Singleton.CreateRegistration(() => registration, container));
		}
	}

	public static void RegisterCqrs(this Container container)
	{
		container.RegisterSingleton<IDispatcher, Dispatcher>();
	}

	public static void RegisterQuery<TQuery, TResult, TQueryHandler>(this Container container)
		where TQuery : IQuery<TResult>
		where TQueryHandler : class, IQueryHandler<TQuery, TResult>
	{
		var registration = Bakery.Cqrs.Registration.Create(() => container.GetInstance<IQueryHandler<TQuery, TResult>>());

		container.RegisterSingleton<TQueryHandler>();
		container.AppendToCollection(typeof(IRegistration), Lifestyle.Singleton.CreateRegistration(() => registration, container));
	}

	public static void RegisterQueryHandler<TQueryHandler>(this Container container)
		where TQueryHandler : class
	{
		foreach (var @interface in typeof(TQueryHandler).GetTypeInfo().GetInterfaces())
		{
			if (!IsQueryHandlerInterface(@interface))
				continue;

			var queryType = @interface.GetTypeInfo().GenericTypeArguments[0];
			var resultType = @interface.GetTypeInfo().GenericTypeArguments[1];
			var registration = Bakery.Cqrs.Registration.Create(queryType, resultType, () => container.GetInstance<TQueryHandler>());

			container.RegisterSingleton(typeof(TQueryHandler), typeof(TQueryHandler));
			container.AppendToCollection(typeof(IRegistration), Lifestyle.Singleton.CreateRegistration(() => registration, container));
		}
	}

	private static Boolean IsCommandHandlerInterface(Type @interface)
	{
		return
			@interface.GetTypeInfo().IsGenericType &&
			@interface.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICommandHandler<>);
	}

	private static Boolean IsQueryHandlerInterface(Type @interface)
	{
		return
			@interface.GetTypeInfo().IsGenericType &&
			@interface.GetTypeInfo().GetGenericTypeDefinition() == typeof(IQueryHandler<,>);
	}
}
