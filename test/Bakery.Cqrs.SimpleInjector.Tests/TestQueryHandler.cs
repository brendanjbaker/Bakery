using Bakery.Cqrs;
using System;
using System.Threading.Tasks;

public class TestQueryHandler
	: IQueryHandler<TestQuery, String>
{
	public Boolean HasReceivedQuery { get; private set; } = false;

	public Task<String> HandleAsync(TestQuery query)
	{
		HasReceivedQuery = true;

		return Task.FromResult("Test");
	}
}
