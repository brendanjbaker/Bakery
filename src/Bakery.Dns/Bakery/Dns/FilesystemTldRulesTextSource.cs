namespace Bakery.Dns
{
	using System;
	using System.IO;
	using System.Text;
	using System.Threading.Tasks;

	public class FilesystemTldRulesTextSource
		: ITldRulesTextSource
	{
		private readonly Encoding encoding;
		private readonly String path;

		public FilesystemTldRulesTextSource(String path)
		{
			this.path = path ?? throw new ArgumentNullException(nameof(path));
		}

		public FilesystemTldRulesTextSource(String path, Encoding encoding)
			: this(path)
		{
			this.encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
		}

		public async Task<String> GetAsync()
		{
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8, encoding == null))
			{
				return await reader.ReadToEndAsync();
			}
		}
	}
}
