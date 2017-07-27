namespace Bakery.Cqrs.Configuration
{
	using System;

	public interface IQueryCachingConfiguration
	{
		TimeSpan? Lifetime { get; }
		Priority? Priority { get; }
	}
}
