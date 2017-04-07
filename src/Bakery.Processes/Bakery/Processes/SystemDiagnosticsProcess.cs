namespace Bakery.Processes
{
	using Collections;
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Threading.Tasks;

	public class SystemDiagnosticsProcess
		: IStartedProcess
	{
		private readonly Process process;
		private readonly IQueue<Output> outputQueue;

		private SystemDiagnosticsProcess(Process process)
		{
			this.process = process;
			this.outputQueue = new Queue<Output>();
		}

		public static IStartedProcess Create(ProcessStartInfo processStartInfo)
		{
			processStartInfo.RedirectStandardError = true;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;

			var process = new Process()
			{
				StartInfo = processStartInfo
			};

			var instance = new SystemDiagnosticsProcess(process);
			var outputGate = new Object();

			process.ErrorDataReceived += (sender, arguments) =>
			{
				if (arguments.Data != null)
					lock (outputGate)
						instance.outputQueue.Enqueue(new Output(OutputType.Error, arguments.Data));
			};

			process.OutputDataReceived += (sender, arguments) =>
			{
				if (arguments.Data != null)
					lock (outputGate)
						instance.outputQueue.Enqueue(new Output(OutputType.Output, arguments.Data));
			};

			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();

			return instance;
		}

		public async Task<Output> TryReadAsync(TimeSpan timeout)
		{
			if (timeout < TimeSpan.Zero)
				throw new ArgumentOutOfRangeException(nameof(timeout));

			return await outputQueue.TryDequeueAsync(timeout);
		}

		public async Task WaitForExit(TimeSpan timeout)
		{
			if (timeout < TimeSpan.Zero)
				throw new ArgumentOutOfRangeException(nameof(timeout));

			if (timeout.TotalMilliseconds > Int32.MaxValue)
				throw new ArgumentOutOfRangeException(nameof(timeout));

			await Task.Yield();

			var exited = process.WaitForExit((Int32)timeout.TotalMilliseconds);

			if (exited)
				process.WaitForExit();
		}

		public async Task WriteAsync(String text)
		{
			await process.StandardInput.WriteAsync(text);
		}
	}
}
