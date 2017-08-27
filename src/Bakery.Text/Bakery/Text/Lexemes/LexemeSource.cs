namespace Bakery.Text.Lexemes
{
	using System;

	public struct LexemeSource
	{
		private readonly Int32 position, line, column;

		public LexemeSource(Int32 position, Int32 line, Int32 column)
		{
			this.position = position;
			this.line = line;
			this.column = column;
		}

		public Int32 Position => position;

		public Int32 Line => line;

		public Int32 Column => column;
	}
}
