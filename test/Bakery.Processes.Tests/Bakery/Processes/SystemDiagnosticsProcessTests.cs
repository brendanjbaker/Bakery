namespace Bakery.Processes
{
	using Specification.Builder;
	using System;
	using System.Text;
	using System.Threading.Tasks;
	using Xunit;

	public class SystemDiagnosticsProcessTests
	{
		[Fact]
		public async Task EchoWithCombinedOutput()
		{
			var processSpecification =
				ProcessSpecificationBuilder.Create()
					.WithProgram(@"echo")
					.WithArguments("a", "b", "c")
					.WithEnvironment()
					.WithCombinedOutput()
					.Build();

			var processFactory = new ProcessFactory();

			var process = processFactory.Start(processSpecification);
			var stringBuilder = new StringBuilder();

			await process.WaitForExit(TimeSpan.FromSeconds(5));

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
