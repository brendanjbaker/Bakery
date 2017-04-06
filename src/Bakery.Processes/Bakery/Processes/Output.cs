namespace Bakery.Processes
{
	using System;

	public struct Output
	{
		private readonly String text;
		private readonly OutputType type;

		public Output(OutputType type, String text)
		{
			this.type = type;
			this.text = text;
		}

		public String Text => text;

		public OutputType Type => type;
	}
}
