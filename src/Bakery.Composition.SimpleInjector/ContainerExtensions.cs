using Bakery.Composition.SimpleInjector;
using SimpleInjector;
using System;

public static class ContainerExtensions
{
	public static void RegisterModule<TModule>(this Container container)
		where TModule : IModule, new()
	{
		container.RegisterModule(new TModule());
	}

	public static void RegisterModule(this Container container, IModule module)
	{
		module.Compose(container);
	}

	public static void RegisterScoped<TService>(this Container container)
		where TService : class
	{
		container.Register<TService>(Lifestyle.Scoped);
	}

	public static void RegisterScoped<TService>(this Container container, Func<TService> instanceCreator)
		where TService : class
	{
		container.Register(instanceCreator, Lifestyle.Scoped);
	}

	public static void RegisterScoped<TService, TImplementation>(this Container container)
		where TService : class
		where TImplementation : class, TService
	{
		container.Register<TService, TImplementation>(Lifestyle.Scoped);
	}

	public static void RegisterTransient<TService>(this Container container)
		where TService : class
	{
		container.Register<TService>(Lifestyle.Transient);
	}

	public static void RegisterTransient<TService>(this Container container, Func<TService> instanceCreator)
		where TService : class
	{
		container.Register(instanceCreator, Lifestyle.Transient);
	}

	public static void RegisterTransient<TService, TImplementation>(this Container container)
		where TService : class
		where TImplementation : class, TService
	{
		container.Register<TService, TImplementation>(Lifestyle.Transient);
	}
}
