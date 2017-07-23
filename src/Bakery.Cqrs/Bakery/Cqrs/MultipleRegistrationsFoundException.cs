namespace Bakery.Cqrs
{
	using System;

	public class MultipleRegistrationsFoundException
		: InvalidOperationException
	{
		private readonly Type type;

		public MultipleRegistrationsFoundException(Type type)
		{
			this.type = type;
		}

		public override String Message => $"Multiple registrations found for {type.Name}.";
	}
}
