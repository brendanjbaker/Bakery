namespace Bakery.Programs
{
	using Bakery.Composition.SimpleInjector;
	using SimpleInjector;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class ProgramBuilder
		: IProgramBuilder
	{
		private Container container;
		private Boolean exitOnControlC;
		private TimeSpan delayAfterUnhandledException;
		private Type programType;

		public ProgramBuilder()
		{
			container = new Container();
		}

		public IProgramBuilder DelayAfterUnhandledException(TimeSpan delay)
		{
			delayAfterUnhandledException = delay;

			return this;
		}

		public IProgramBuilder ExitOnControlC(Boolean enabled = true)
		{
			exitOnControlC = enabled;

			return this;
		}

		public IProgramBuilder RegisterModule<TModule>() where TModule : IModule, new()
		{
			container.RegisterModule<TModule>();

			return this;
		}

		public void Run()
		{
			RunAsync().GetAwaiter().GetResult();
		}

		public async Task RunAsync()
		{
			container.Verify();

			var program = (IProgram)container.GetInstance(programType);
			var cancellationToken = CancellationToken.None;

			if (exitOnControlC)
			{
				var cancellationTokenSource = new CancellationTokenSource();

				cancellationToken = cancellationTokenSource.Token;

				Console.CancelKeyPress += (sender, e) =>
				{
					e.Cancel = true;

					cancellationTokenSource.Cancel();
				};
			}

			try
			{
				await program.RunAsync(cancellationToken);
			}
			catch
			{
				if (delayAfterUnhandledException >= TimeSpan.Zero)
					await Task.Delay(delayAfterUnhandledException);

				throw;
			}

			container.Dispose();
		}

		public IProgramBuilder UseProgram<TProgram>() where TProgram : IProgram
		{
			programType = typeof(TProgram);

			return this;
		}
	}
}
