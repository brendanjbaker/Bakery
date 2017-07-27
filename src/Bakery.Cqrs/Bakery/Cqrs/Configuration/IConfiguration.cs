namespace Bakery.Cqrs.Configuration
{
	using System;

	public interface IConfiguration
	{
		Boolean AllowMultipleCommandDispatch { get; }
		Boolean AllowVoidCommandDispatch { get; }
		ICachingConfiguration CachingConfiguration { get; }
	}
}
