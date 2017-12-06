namespace Bakery.Programs
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public static class StandardProgram
	{
		public static void Run<TProgram>() where TProgram : class, IProgram
			=> Run<TProgram>(options => { });

		public static void Run<TProgram>(Action<IStandardProgramOptions> configure) where TProgram : class, IProgram
			=> RunAsync<TProgram>(configure).GetAwaiter().GetResult();

		public static Task RunAsync<TProgram>() where TProgram : class, IProgram
			=> RunAsync<TProgram>(options => { });

		public static async Task RunAsync<TProgram>(Action<IStandardProgramOptions> configure)
			where TProgram : class, IProgram
		{
			var options = new StandardProgramOptions();

			configure(options);

			try
			{
				var program = options.Container.GetInstance<TProgram>();

				using (var cancellationTokenSource = new CancellationTokenSource())
				{
					var cancellationToken = cancellationTokenSource.Token;

					Console.CancelKeyPress += (sender, e) =>
					{
						e.Cancel = true;

						cancellationTokenSource.Cancel();
					};

					await program.RunAsync(cancellationToken);
				}
			}
			catch (Exception e)
			{
				await Console.Error.WriteLineAsync(e.ToString());

				if (Environment.ExitCode == 0)
					Environment.ExitCode = 1;

				if (options.Delay.HasValue)
					await Task.Delay(options.Delay.Value);
			}
		}
	}
}
