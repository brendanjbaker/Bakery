namespace Bakery.Cqrs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class QueryDispatcher
		: IQueryDispatcher
	{
		private readonly IEnumerable<IRegistration> registrations;

		public QueryDispatcher(IEnumerable<IRegistration> registrations)
		{
			if (registrations == null)
				throw new ArgumentNullException(nameof(registrations));

			this.registrations = registrations;
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var queryType = query.GetType();
			var matching = GetMatchingRegistrations(queryType);

			if (matching.None())
				throw new NoRegistrationFoundException(queryType);

			if (matching.Multiple())
				throw new MultipleRegistrationsFoundException(queryType);

			var result = await matching.Single().ExecuteAsync(query);

			return (TResult)result;
		}

		private IRegistration[] GetMatchingRegistrations(Type queryType)
		{
			return registrations.Where(r => r.Type == queryType).ToArray();
		}
	}
}
