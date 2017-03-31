namespace Bakery.Properties
{
	using System;
	using System.Collections.Generic;

	public interface IProperties
	{
		IDictionary<String, String> ToDictionary();
	}
}
