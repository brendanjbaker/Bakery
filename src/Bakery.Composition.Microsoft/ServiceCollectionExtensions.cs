using Bakery.Composition.Microsoft;
using Microsoft.Extensions.DependencyInjection;
using System;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddModule<TModule>(this IServiceCollection serviceCollection)
		where TModule : IModule, new()
	{
		new TModule().Compose(serviceCollection);

		return serviceCollection;
	}

	public static IServiceCollection AddSingleton<TService>(this IServiceCollection serviceCollection, Func<TService> factory)
		where TService : class
	{
		return serviceCollection.AddSingleton(serviceProvider =>
		{
			return factory();
		});
	}
}
