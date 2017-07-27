namespace Bakery.Cqrs.Configuration.Builder
{
	using System;

	public interface IConfigurationBuilder
	{
		IConfigurationBuilder AllowMultipleCommandDispatch();
		IConfigurationBuilder AllowVoidCommandDispatch();

		IConfigurationBuilder DisallowMultipleCommandDispatch();
		IConfigurationBuilder DisallowVoidCommandDispatch();

		IConfigurationBuilder EnableCaching(Action<ICachingConfigurationBuilder> builderFunction);

		IConfiguration Build();
	}
}
