namespace Bakery.Text
{
	using System;

	public class SystemUuidParser
		: IUuidParser
	{
		public Uuid? TryParse(String @string)
		{
			Guid guid;

			if (!Guid.TryParse(@string, out guid))
				return null;

			return new Uuid(guid);
		}
	}
}
