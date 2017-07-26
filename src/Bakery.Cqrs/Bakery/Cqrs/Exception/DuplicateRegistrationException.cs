namespace Bakery.Cqrs.Exception
{
	using System;

	public class DuplicateRegistrationException
		: InvalidOperationException
	{
		private readonly Type type;

		public DuplicateRegistrationException(Type type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			this.type = type;
		}

		public override String Message => $"Multiple registrations found for {type.Name}.";
	}
}
