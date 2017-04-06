using Bakery.Processes;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public static class ProcessFactoryExtensions
{
	public static async Task<IProcess> RunAsync(this IProcessFactory processFactory, ProcessStartInfo processStartInfo)
	{
		return await processFactory.RunAsync(processStartInfo, TimeSpan.FromMinutes(1));
	}

	public static async Task<IProcess> RunAsync(this IProcessFactory processFactory, ProcessStartInfo processStartInfo, TimeSpan timeout)
	{
		var process = processFactory.Start(processStartInfo);

		await process.WaitForExit(timeout);

		return process;
	}
}
