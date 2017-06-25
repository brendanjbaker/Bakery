using Bakery.Composition.SimpleInjector;
using SimpleInjector;

public static class ContainerExtensions
{
	public static void RegisterModule<TModule>(this Container container)
		where TModule : IModule, new()
	{
		new TModule().Compose(container);
	}

	public static void RegisterScoped<TService, TImplementation>(this Container container)
		where TService : class
		where TImplementation : class, TService
	{
		container.Register<TService, TImplementation>(Lifestyle.Scoped);
	}

	public static void RegisterTransient<TService, TImplementation>(this Container container)
		where TService : class
		where TImplementation : class, TService
	{
		container.Register<TService, TImplementation>(Lifestyle.Transient);
	}
}
