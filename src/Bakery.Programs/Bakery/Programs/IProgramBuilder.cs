namespace Bakery.Programs
{
	using Bakery.Composition.SimpleInjector;
	using System;
	using System.Threading.Tasks;

	public interface IProgramBuilder
	{
		IProgramBuilder ExitOnControlC(Boolean enabled = true);
		IProgramBuilder DelayAfterUnhandledException(TimeSpan delay);
		IProgramBuilder RegisterModule<TModule>() where TModule : IModule, new();
		IProgramBuilder UseProgram<TProgram>() where TProgram : IProgram;

		void Run();
		Task RunAsync();
	}
}
