namespace Bakery.Cqrs.Configuration
{
	using System;

	public class Configuration
		: IConfiguration
	{
		public Configuration(Boolean allowMultipleCommandDispatch)
		{
			AllowMultipleCommandDispatch = allowMultipleCommandDispatch;
		}

		public Configuration(Boolean allowMultipleCommandDispatch, ICachingConfiguration cachingConfiguration)
		{
			AllowMultipleCommandDispatch = allowMultipleCommandDispatch;
			CachingConfiguration = cachingConfiguration;
		}

		public Boolean AllowMultipleCommandDispatch { get; private set; }
		public ICachingConfiguration CachingConfiguration { get; private set; }
	}
}
