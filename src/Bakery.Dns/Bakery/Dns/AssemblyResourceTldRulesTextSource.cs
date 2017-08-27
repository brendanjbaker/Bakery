namespace Bakery.Dns
{
	using System;
	using System.IO;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;

	public class AssemblyResourceTldRulesTextSource
		: ITldRulesTextSource
	{
		private readonly Assembly assembly;
		private readonly Encoding encoding;
		private readonly String path;

		public AssemblyResourceTldRulesTextSource(Assembly assembly, String path)
		{
			this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
			this.path = path ?? throw new ArgumentNullException(nameof(path));
		}

		public AssemblyResourceTldRulesTextSource(Assembly assembly, String path, Encoding encoding)
			: this(assembly, path)
		{
			this.encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
		}

		public async Task<String> GetAsync()
		{
			var assemblyPath = String.Format("{0}.{1}", assembly.GetName().Name, path);

			using (var stream = assembly.GetManifestResourceStream(assemblyPath))
			using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8, encoding == null))
			{
				return await reader.ReadToEndAsync();
			}
		}
	}
}
