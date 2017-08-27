namespace Bakery.Dns
{
	using System;
	using System.Net.Http;
	using System.Threading.Tasks;

	public class HttpTldRulesTextSource
		: ITldRulesTextSource
	{
		private readonly String url;

		public HttpTldRulesTextSource(String url)
		{
			this.url = url ?? throw new ArgumentNullException(nameof(url));
		}

		public async Task<String> GetAsync()
		{
			using (var httpClient = new HttpClient())
			{
				return await httpClient.GetStringAsync(url);
			}
		}
	}
}
