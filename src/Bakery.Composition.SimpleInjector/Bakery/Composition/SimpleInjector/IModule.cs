namespace Bakery.Composition.SimpleInjector
{
	using global::SimpleInjector;

	public interface IModule
	{
		void Compose(Container container);
	}
}
