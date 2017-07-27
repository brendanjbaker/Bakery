namespace Bakery.Cqrs
{
	using System;

	public interface IHandlerResolver
	{
		Object[] GetHandlers(Type handlerType);
	}
}
