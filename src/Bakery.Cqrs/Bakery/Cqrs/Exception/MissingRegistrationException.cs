namespace Bakery.Cqrs.Exception
{
	using System;

	public class MissingRegistrationException
		: InvalidOperationException
	{
		private readonly Type type;

		public MissingRegistrationException(Type type)
		{
			this.type = type;
		}

		public override String Message => $"Registration not found for {type.Name}.";
	}
}
