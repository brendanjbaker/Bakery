namespace Bakery.Cqrs
{
	using SimpleInjector;
	using System;
	using System.Linq;

	public class SimpleInjectorHandlerResolver
		: IHandlerResolver
	{
		private readonly Container container;

		public SimpleInjectorHandlerResolver(Container container)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			this.container = container;
		}

		public Object[] GetHandlers(Type handlerType)
		{
			if (handlerType == null)
				throw new ArgumentNullException(nameof(handlerType));

			return container.GetAllInstances(handlerType).ToArray();
		}
	}
}
