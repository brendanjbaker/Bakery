namespace Bakery.Cqrs
{
	using System;

	public class NoRegistrationFoundException
		: InvalidOperationException
	{
		private readonly Type type;

		public NoRegistrationFoundException(Type type)
		{
			this.type = type;
		}

		public override String Message => $"Registration not found for {type.Name}.";
	}
}
