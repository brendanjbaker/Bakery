namespace Bakery.Cqrs.Configuration.Builder
{
	using System;

	public class ConfigurationBuilder
		: IConfigurationBuilder
	{
		private Boolean? allowMultipleCommandDispatch, allowVoidCommandDispatch;
		private ICachingConfiguration cachingConfiguration;

		public IConfigurationBuilder AllowMultipleCommandDispatch()
		{
			return Builder.SetOption(this, ref allowMultipleCommandDispatch, () => true);
		}

		public IConfigurationBuilder AllowVoidCommandDispatch()
		{
			return Builder.SetOption(this, ref allowVoidCommandDispatch, () => true);
		}

		public IConfigurationBuilder DisallowMultipleCommandDispatch()
		{
			return Builder.SetOption(this, ref allowMultipleCommandDispatch, () => false);
		}

		public IConfigurationBuilder DisallowVoidCommandDispatch()
		{
			return Builder.SetOption(this, ref allowVoidCommandDispatch, () => false);
		}

		public IConfigurationBuilder EnableCaching(Func<ICachingConfigurationBuilder, ICachingConfiguration> builder)
		{
			return Builder.SetOption(this, ref cachingConfiguration, () => builder(new CachingConfigurationBuilder()));
		}

		public IConfiguration Build()
		{
			return new Configuration(
				allowMultipleCommandDispatch: allowMultipleCommandDispatch ?? true,
				allowVoidCommandDispatch: allowVoidCommandDispatch ?? false,
				cachingConfiguration: cachingConfiguration);
		}
	}
}
