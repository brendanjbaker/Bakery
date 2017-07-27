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

		public IConfigurationBuilder EnableCaching(Action<ICachingConfigurationBuilder> builderFunction)
		{
			if (builderFunction == null)
				throw new ArgumentNullException(nameof(builderFunction));

			return Builder.SetOption(this, ref cachingConfiguration, () =>
			{
				var builder = new CachingConfigurationBuilder();

				builderFunction(builder);

				return builder.Build();
			});
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
