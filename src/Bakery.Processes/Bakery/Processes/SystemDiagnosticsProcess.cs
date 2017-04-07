namespace Bakery.Processes
{
	using Collections;
	using Specification;
	using System;
	using System.Diagnostics;
	using System.Linq;
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

		public static IStartedProcess Create(IProcessSpecification processSpecification)
		{
			var process = new Process()
			{
				StartInfo = new ProcessStartInfo()
				{
					CreateNoWindow = true,
					UseShellExecute = false
				}
			};

			if (processSpecification.IsEnvironmentEnabled)
			{
				process.StartInfo.LoadUserProfile = true;

				process.StartInfo.Environment.Add("HOME", Environment.GetEnvironmentVariable("USERPROFILE"));
			}

			if (processSpecification.IsStandardInputEnabled)
				process.StartInfo.RedirectStandardInput = true;

			if (processSpecification.OutputMode == OutputMode.StandardOutput)
			{
				process.StartInfo.RedirectStandardOutput = true;
			}
			else if (processSpecification.OutputMode == OutputMode.StandardError)
			{
				process.StartInfo.RedirectStandardError = true;
			}
			else if (processSpecification.OutputMode == OutputMode.StandardOutputAndError)
			{
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.RedirectStandardOutput = true;
			}

			var hasReceivedOutput = false;
			var hasReceivedError = false;

			if (processSpecification.OutputMode == OutputMode.Combined)
			{
				process.StartInfo.FileName = "cmd.exe";
				//process.StartInfo.Arguments = String.Format("/C \"{0} {1}\"2>&1", processSpecification.Program, String.Join(" ", processSpecification.Arguments).Replace("\"", "\"\""));

				if (processSpecification.Arguments.Any())
				{
					process.StartInfo.Arguments = String.Format("/C \"({0} {1})\" 2>&1", processSpecification.Program, String.Join(" ", processSpecification.Arguments));
				}
				else
				{
					process.StartInfo.Arguments = String.Format("/C \"({0})\" 2>&1", processSpecification.Program);
				}

				process.StartInfo.RedirectStandardOutput = true;
			}
			else
			{
				process.StartInfo.FileName = processSpecification.Program;
				process.StartInfo.Arguments = String.Join(" ", processSpecification.Arguments);
			}

			var instance = new SystemDiagnosticsProcess(process);
			var outputGate = new Object();

			process.ErrorDataReceived += (sender, arguments) =>
			{
				if (arguments.Data == null)
					return;

				lock (outputGate)
				{
					var text = arguments.Data;

					if (hasReceivedError)
					{
						text = Environment.NewLine + text;
					}
					else
					{
						hasReceivedError = true;
					}

					instance.outputQueue.Enqueue(new Output(OutputType.Error, text));
				}
			};

			process.OutputDataReceived += (sender, arguments) =>
			{
				if (arguments.Data == null)
					return;

				lock (outputGate)
				{
					var text = arguments.Data;

					if (hasReceivedOutput)
					{
						text = Environment.NewLine + text;
					}
					else
					{
						hasReceivedOutput = true;
					}

					var outputType = processSpecification.OutputMode == OutputMode.Combined
						? OutputType.Combined
						: OutputType.Output;

					instance.outputQueue.Enqueue(new Output(outputType, text));
				}
			};

			process.Start();

			if (process.StartInfo.RedirectStandardOutput)
				process.BeginOutputReadLine();

			if (process.StartInfo.RedirectStandardError)
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
