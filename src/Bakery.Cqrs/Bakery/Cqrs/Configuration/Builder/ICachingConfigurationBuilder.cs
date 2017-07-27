namespace Bakery.Cqrs.Configuration.Builder
{
	using System;

	public interface ICachingConfigurationBuilder
	{
		ICachingConfigurationBuilder Cache<TQuery>();
		ICachingConfigurationBuilder Cache<TQuery>(TimeSpan lifetime);
		ICachingConfigurationBuilder Cache<TQuery>(Priority priority);
		ICachingConfigurationBuilder Cache<TQuery>(TimeSpan lifetime, Priority priority);

		ICachingConfigurationBuilder SetAdapter(ReadDelegate read, WriteDelegate write);
		ICachingConfigurationBuilder SetDefaultLifetime(TimeSpan lifetime);
		ICachingConfigurationBuilder SetDefaultPriority(Priority priority);

		ICachingConfiguration Build();
	}
}
