using Bakery.Cqrs;
using System;
using System.Threading.Tasks;

public class RandomGuidQueryHandler
	: IQueryHandler<RandomGuidQuery, Guid>
{
	public Task<Guid> HandleAsync(RandomGuidQuery query)
	{
		return Task.FromResult(Guid.NewGuid());
	}
}
