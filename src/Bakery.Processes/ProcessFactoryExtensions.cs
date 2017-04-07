using Bakery.Processes;
using Bakery.Processes.Specification;
using System;
using System.Threading.Tasks;

public static class ProcessFactoryExtensions
{
	public static async Task<IProcess> RunAsync(this IProcessFactory processFactory, IProcessSpecification processSpecification)
	{
		return await processFactory.RunAsync(processSpecification, TimeSpan.FromMinutes(1));
	}

	public static async Task<IProcess> RunAsync(this IProcessFactory processFactory, IProcessSpecification processSpecification, TimeSpan timeout)
	{
		var process = processFactory.Start(processSpecification);

		await process.WaitForExit(timeout);

		return process;
	}
}
