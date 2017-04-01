namespace Bakery.Properties
{
	using System;
	using System.Collections.Generic;

	public class EmptyProperties
		: IProperties
	{
		public IDictionary<String, String> ToDictionary()
		{
			return new Dictionary<String, String>(0);
		}
	}
}
