namespace Bakery.Properties
{
	using System;

	public class PropertyNotFoundException
		: Exception
	{
		private readonly String propertyName;

		public PropertyNotFoundException(String propertyName)
		{
			if (propertyName == null)
				throw new ArgumentNullException(nameof(propertyName));

			this.propertyName = propertyName;
		}

		public override String Message => $"Property \"{propertyName}\" not found.";
	}
}
