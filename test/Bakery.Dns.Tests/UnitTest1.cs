namespace Bakery.Dns.Tests
{
	using Bakery.Text;
	using System;
	using System.Threading.Tasks;
	using Xunit;

	public class UnitTest1
	{
		[Theory]
		[InlineData("example.co.uk", null, "example", "co.uk")]
		[InlineData("a.example.co.uk", "a", "example", "co.uk")]
		[InlineData("a.b.example.co.uk", "a.b", "example", "co.uk")]
		[InlineData("a.b.c.example.co.uk", "a.b.c", "example", "co.uk")]
		public async Task Test1(String domainNameText, String subdomain, String sld, String tld)
		{
			var domainNameParser =
				new DomainNameParser(
					new TldRuleCollection(
						new TldRulesSource(
							new TldRulesParser(
								new CrossPlatformLineSplitter(),
								null),
							new HttpTldRulesTextSource("https://publicsuffix.org/list/public_suffix_list.dat"))));

			var domainName = await domainNameParser.ParseAsync(domainNameText);

			if (subdomain != null)
				Assert.Equal(subdomain, String.Join(".", domainName.Subdomains));

			Assert.Equal(sld, domainName.Sld);
			Assert.Equal(tld, domainName.Tld.ToString());
		}
	}
}
