namespace Bakery.Logging
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Threading;
	using System.Threading.Tasks;

	public class BufferedConsoleLog
		: ILog
	{
		private static readonly Queue<ConsoleMessage> output;
		private static readonly Semaphore outputGate;

		static BufferedConsoleLog()
		{
			output = new Queue<ConsoleMessage>();
			outputGate = new Semaphore(0, Int32.MaxValue);

			Task.Run(() =>
			{
				ConsoleMessage consoleMessage;

				while (true)
				{
					outputGate.WaitOne();

					lock (output)
						consoleMessage = output.Dequeue();

					consoleMessage.Writer.WriteLine(consoleMessage.Text);
				}
			});
		}

		public void Write(Level logLevel, String message)
		{
			if (message == null)
				throw new ArgumentNullException(message);

			var textWriter = logLevel >= Level.Warning
				? Console.Error
				: Console.Out;

			lock (output)
				output.Enqueue(new ConsoleMessage()
				{
					Text = message,
					Writer = textWriter
				});

			outputGate.Release();
		}

		private class ConsoleMessage
		{
			public TextWriter Writer { get; set; }
			public String Text { get; set; }
		}
	}
}
