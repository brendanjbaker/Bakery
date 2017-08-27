namespace Bakery.Dns
{
	using System;
	using System.Text;

	public struct DomainName
	{
		private readonly Tld tld;
		private readonly String sld;
		private readonly String[] subdomains;

		public DomainName(String sld, Tld tld)
			: this(Array.Empty<String>(), sld, tld) { }

		public DomainName(String[] subdomains, String sld, Tld tld)
		{
			if (subdomains == null)
				throw new ArgumentNullException(nameof(subdomains));

			if (sld == null)
				throw new ArgumentNullException(nameof(sld));

			this.subdomains = subdomains;
			this.sld = sld;
			this.tld = tld;
		}

		public String Sld => sld;

		public String[] Subdomains => subdomains;

		public Tld Tld => tld;

		public override string ToString()
		{
			var builder = new StringBuilder();

			foreach (var subdomain in subdomains)
			{
				builder
					.Append(subdomain)
					.Append(".");
			}

			builder
				.Append(sld)
				.Append(".")
				.Append(tld.ToString());

			return builder.ToString();
		}
	}
}
