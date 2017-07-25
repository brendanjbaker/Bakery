using Bakery.Cqrs;
using SimpleInjector;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

public class ContainerExtensionsTests
{
	[Fact]
	public void RegisterCommandHandler()
	{
		var container = new Container();

		container.RegisterCqrs(options =>
		{
			options.ScanAssembly(typeof(ContainerExtensionsTests).GetTypeInfo().Assembly);
		});

		container.Verify();

		var handler = container.GetInstance<TestCommandHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		dispatcher.CommandAsync(new TestCommand()).Wait();

		Assert.True(handler.HasReceivedCommand);
	}

	[Fact]
	public async Task RegisterQueryHandler()
	{
		var container = new Container();

		container.RegisterCqrs(options =>
		{
			options.ScanAssembly(typeof(ContainerExtensionsTests).GetTypeInfo().Assembly);
		});

		container.Verify();

		var handler = container.GetInstance<TestQueryHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		var result = await dispatcher.QueryAsync(new TestQuery());

		Assert.True(handler.HasReceivedQuery);
	}

	[Fact]
	public async Task EnableCaching()
	{
		var container = new Container();

		container.RegisterCqrs(cqrsOptions =>
		{
			cqrsOptions.ScanAssembly(typeof(ContainerExtensionsTests).GetTypeInfo().Assembly);

			cqrsOptions.EnableCaching(cachingOptions =>
			{
				cachingOptions.AddQuery<RandomGuidQuery>(TimeSpan.FromMinutes(1));
			});
		});

		container.Verify();

		var handler = container.GetInstance<CountingTestQueryHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		var guid1 = await dispatcher.QueryAsync(new RandomGuidQuery());
		var guid2 = await dispatcher.QueryAsync(new RandomGuidQuery());

		Assert.Equal(guid1, guid2);
	}
}
