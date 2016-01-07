namespace Bakery.Configuration.Properties
{
	using System;

	public class PropertyNotFoundException
		: Exception
	{
		private readonly String propertyName;

		public PropertyNotFoundException(String propertyName)
		{
			this.propertyName = propertyName;
		}

		public override String Message
		{
			get
			{
				return $"Property \"{propertyName}\" not found.";
			}
		}
	}
}
