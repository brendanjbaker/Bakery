namespace Bakery.Text
{
	using System;

	public class CrossPlatformLineSplitter
		: ILineSplitter
	{
		public String[] SplitLines(String @string)
		{
			if (@string == null)
				throw new ArgumentNullException(nameof(@string));

			return @string
				.Replace("\r\n", "\n")
				.Replace("\r", "\n")
				.Split('\n');
		}
	}
}
