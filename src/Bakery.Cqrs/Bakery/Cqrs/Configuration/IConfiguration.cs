namespace Bakery.Cqrs.Configuration
{
	using System;

	public interface IConfiguration
	{
		Boolean AllowMultipleCommandDispatch { get; }
		ICachingConfiguration CachingConfiguration { get; }
	}
}
