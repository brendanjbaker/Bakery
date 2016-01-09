namespace Bakery.Logging
{
	using System;

	public interface ILog
	{
		void Write(Level logLevel, String message);
	}
}
