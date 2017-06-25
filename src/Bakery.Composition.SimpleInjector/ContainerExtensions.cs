using Bakery.Composition.SimpleInjector;
using SimpleInjector;

public static class ContainerExtensions
{
	public static void RegisterModule<TModule>(this Container container)
		where TModule : IModule, new()
	{
		new TModule().Compose(container);
	}
}
