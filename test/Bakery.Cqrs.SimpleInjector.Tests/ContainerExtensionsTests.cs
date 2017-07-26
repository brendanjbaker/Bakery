using Bakery.Cqrs;
using Bakery.Cqrs.Configuration;
using Bakery.Time;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

public class ContainerExtensionsTests
{
	[Fact]
	public async Task RegisterCommandHandler()
	{
		var configuration = new Configuration(allowMultipleCommandDispatch: true);
		var container = new Container();

		container.RegisterCqrs(configuration);
		container.RegisterSingleton<TestCommandHandler, TestCommandHandler>();
		container.RegisterCommandHandlers(GetType().GetTypeInfo().Assembly);
		container.Verify();

		var handler = container.GetInstance<TestCommandHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		await dispatcher.CommandAsync(new TestCommand());

		Assert.True(handler.HasReceivedCommand);
	}

	[Fact]
	public async Task RegisterQueryHandler()
	{
		var configuration = new Configuration(allowMultipleCommandDispatch: true);
		var container = new Container();

		container.RegisterCqrs(configuration);
		container.RegisterSingleton<TestQueryHandler, TestQueryHandler>();
		container.RegisterQueryHandlers(GetType().GetTypeInfo().Assembly);
		container.Verify();

		var handler = container.GetInstance<TestQueryHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();
		var result = await dispatcher.QueryAsync(new TestQuery());

		Assert.True(handler.HasReceivedQuery);
	}

	[Fact]
	public async Task EnableCaching()
	{
		var queryCache = new QueryCache(new SystemClock());

		var configuration = new Configuration(
			allowMultipleCommandDispatch: true,
			cachingConfiguration: new CachingConfiguration(
				defaultLifetime: TimeSpan.FromMinutes(1),
				defaultPriority: Priority.Normal,
				read: query => queryCache.TryRead(query),
				write: (query, result, lifetime, priority) => queryCache.Write(query, result, lifetime),
				queryCachingConfigurations: new Dictionary<Type, IQueryCachingConfiguration>()
				{
					{ typeof(RandomGuidQuery), new QueryCachingConfiguration(TimeSpan.FromMinutes(1)) }
				}));

		var container = new Container();

		container.RegisterCqrs(configuration);
		container.RegisterHandlers(GetType().GetTypeInfo().Assembly);
		container.Verify();

		var dispatcher = container.GetInstance<IDispatcher>();
		var guid1 = await dispatcher.QueryAsync(new RandomGuidQuery());
		var guid2 = await dispatcher.QueryAsync(new RandomGuidQuery());

		Assert.Equal(guid1, guid2);
	}
}
