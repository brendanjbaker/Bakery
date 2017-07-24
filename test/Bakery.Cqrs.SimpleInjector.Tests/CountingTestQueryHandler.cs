using Bakery.Cqrs;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CountingTestQueryHandler
	: IQueryHandler<CountingTestQuery, String>
{
	public Int32 ExecutionCount;

	public Task<String> HandleAsync(CountingTestQuery query)
	{
		Interlocked.Increment(ref ExecutionCount);

		return Task.FromResult("Test");
	}
}
