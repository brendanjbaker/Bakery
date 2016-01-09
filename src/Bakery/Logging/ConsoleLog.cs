namespace Bakery.Logging
{
	using System;
	using Time;

	public class ConsoleLog
		: ILog
	{
		private readonly IClock clock;

		public ConsoleLog(IClock clock)
		{
			this.clock = clock;
		}

		public void Write(Level logLevel, String message)
		{
			const String FORMAT = "{0}: [{1}] {2}";

			var textWriter = logLevel >= Level.Warning
				? Console.Error
				: Console.Out;

			textWriter.WriteLine(
				String.Format(
					FORMAT,
					clock.GetUniversalTime().ToString(),
					logLevel,
					message));
		}
	}
}
