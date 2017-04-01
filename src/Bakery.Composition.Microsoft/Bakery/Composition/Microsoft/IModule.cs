namespace Bakery.Composition.Microsoft
{
	using global::Microsoft.Extensions.DependencyInjection;

	public interface IModule
	{
		void Compose(IServiceCollection serviceCollection);
	}
}
