namespace Bakery.Dns
{
	using System;

	public struct Tld
	{
		private readonly String name;

		public Tld(String name)
		{
			this.name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public override string ToString()
		{
			return name;
		}
	}
}
