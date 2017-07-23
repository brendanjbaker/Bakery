using Bakery.Cqrs;
using SimpleInjector;
using System.Threading.Tasks;
using Xunit;

public class ContainerExtensionsTests
{
	[Fact]
	public void RegisterCommandHandler()
	{
		var container = new Container();

		container.RegisterCommandHandler<TestCommandHandler>();
		container.RegisterSingleton<IDispatcher, Dispatcher>();

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

		container.RegisterQueryHandler<TestQueryHandler>();
		container.RegisterSingleton<IDispatcher, Dispatcher>();

		container.Verify();

		var handler = container.GetInstance<TestQueryHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		var result = await dispatcher.QueryAsync(new TestQuery());

		Assert.Equal("Test", result);
	}
}
