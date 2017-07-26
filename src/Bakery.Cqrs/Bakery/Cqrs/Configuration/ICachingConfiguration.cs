namespace Bakery.Cqrs.Configuration
{
	using System;
	using System.Collections.Generic;

	public interface ICachingConfiguration
	{
		TimeSpan DefaultLifetime { get; }
		Priority DefaultPriority { get; }
		ReadDelegate Read { get; }
		WriteDelegate Write { get; }
		IDictionary<Type, IQueryCachingConfiguration> QueryCachingConfigurations { get; }
	}
}
