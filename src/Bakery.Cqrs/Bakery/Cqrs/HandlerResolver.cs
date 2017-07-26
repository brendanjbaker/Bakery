namespace Bakery.Cqrs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class HandlerResolver
		: IHandlerResolver
	{
		private readonly IEnumerable<IRegistration> registrations;

		public HandlerResolver(IEnumerable<IRegistration> registrations)
		{
			if (registrations == null)
				throw new ArgumentNullException(nameof(registrations));

			this.registrations = registrations;
		}

		public Object[] GetHandlers(Type handlerType)
		{
			if (handlerType == null)
				throw new ArgumentNullException(nameof(handlerType));

			return registrations
				.Where(r => r.Type == handlerType)
				.ToArray();
		}
	}
}
