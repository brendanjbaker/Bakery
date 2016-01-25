namespace Bakery.Logging
{
	using System;

	public class ConsoleLog
		: ILog
	{
		public void Write(Level logLevel, String message)
		{
			var textWriter = logLevel >= Level.Warning
				? Console.Error
				: Console.Out;

			textWriter.WriteLine(message);
		}
	}
}
