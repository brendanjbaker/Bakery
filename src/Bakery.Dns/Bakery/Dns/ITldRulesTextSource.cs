namespace Bakery.Dns
{
	using System;
	using System.Threading.Tasks;

	public interface ITldRulesTextSource
	{
		Task<String> GetAsync();
	}
}
