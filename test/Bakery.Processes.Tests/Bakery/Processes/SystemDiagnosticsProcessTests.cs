namespace Bakery.Processes
{
	using System;
	using System.Text;
	using System.Threading.Tasks;
	using Xunit;

	public class SystemDiagnosticsProcessTests
	{
		[Fact]
		public async Task EchoWithCombinedOutput()
		{
			var process = await new ProcessFactory().RunAsync(builder =>
			{
				return builder
					.WithProgram("echo")
					.WithArguments("a", "b", "c")
					.WithEnvironment()
					.WithCombinedOutput()
					.Build();
			});

			var stringBuilder = new StringBuilder();

			while (true)
			{
				var output = await process.TryReadAsync(TimeSpan.FromSeconds(1));

				if (output == null)
					break;

				stringBuilder.Append(output.Text);
			}

			var totalOutput = stringBuilder.ToString();

			Assert.Equal("a b c", totalOutput);
		}
	}
}
