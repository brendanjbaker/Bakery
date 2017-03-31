namespace Bakery.Logging
{
	using System;

	public static class LogExtensions
	{
		public static void Write(this ILog log, Level logLevel, String message, params Object[] parameters)
		{
			if (parameters != null && parameters.Length > 0)
				message = String.Format(message, parameters);

			log.Write(logLevel, message);
		}

		public static void WriteDebug(this ILog log, String message, params Object[] parameters)
		{
			log.Write(Level.Debug, message, parameters);
		}

		public static void WriteError(this ILog log, String message, params Object[] parameters)
		{
			log.Write(Level.Error, message, parameters);
		}

		public static void WriteInformation(this ILog log, String message, params Object[] parameters)
		{
			log.Write(Level.Information, message, parameters);
		}

		public static void WriteWarning(this ILog log, String message, params Object[] parameters)
		{
			log.Write(Level.Warning, message, parameters);
		}
	}
}
