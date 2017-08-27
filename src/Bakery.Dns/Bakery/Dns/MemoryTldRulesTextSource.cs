namespace Bakery.Dns
{
	using System;
	using System.Threading.Tasks;

	public class MemoryTldRulesTextSource
		: ITldRulesTextSource
	{
		private readonly String text;

		public MemoryTldRulesTextSource(String text)
		{
			this.text = text ?? throw new ArgumentNullException(nameof(text));
		}

		public Task<String> GetAsync()
		{
			return Task.FromResult(text);
		}
	}
}
