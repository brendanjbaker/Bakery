namespace Bakery.Programs
{
	using Bakery.Composition.SimpleInjector;
	using SimpleInjector;
	using System;

	public class StandardProgramOptions
		: IStandardProgramOptions
	{
		public Container Container { get; private set; } = new Container();

		public TimeSpan? Delay { get; private set; } = TimeSpan.Zero;

		public void DelayAfterException(TimeSpan delay)
		{
			if (delay <= TimeSpan.Zero)
				throw new ArgumentOutOfRangeException(nameof(delay));

			Delay = delay;
		}

		public void RegisterModule<TModule>() where TModule : IModule, new()
		{
			Container.RegisterModule<TModule>();
		}
	}
}
