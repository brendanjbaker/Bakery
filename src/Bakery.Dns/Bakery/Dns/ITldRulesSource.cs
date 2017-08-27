namespace Bakery.Dns
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface ITldRulesSource
	{
		Task<IEnumerable<ITldRule>> ListAsync();
	}
}
