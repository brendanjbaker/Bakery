namespace Bakery.Programs
{
	using Bakery.Composition.SimpleInjector;
	using System;

	public interface IStandardProgramOptions
	{
		void DelayAfterException(TimeSpan delay);
		void RegisterModule<TModule>() where TModule : IModule, new();
	}
}
